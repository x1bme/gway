using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace ApiGateway.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet("connect/authorize")]
        [HttpPost("connect/authorize")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Authorize()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                          throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");
            
            // Retrieve the user principal stored in the authentication cookie.
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // If the user principal can't be extracted, redirect the user to the login page.
            if (!result.Succeeded)
            {
                return Challenge(
                    authenticationSchemes: CookieAuthenticationDefaults.AuthenticationScheme,
                    properties: new AuthenticationProperties
                    {
                        RedirectUri = Request.PathBase + Request.Path + QueryString.Create(
                            Request.HasFormContentType ? Request.Form.ToList() : Request.Query.ToList())
                    });
            }
            var roles = result.Principal.FindAll(ClaimTypes.Role).ToList();

            // Create a new claims principal
            var claims = new List<Claim>
            {
                // 'subject' claim which is required
                new Claim(OpenIddictConstants.Claims.Subject, result.Principal.Identity.Name),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(OpenIddictConstants.Claims.Role, role.Value)
                .SetDestinations(OpenIddictConstants.Destinations.AccessToken, OpenIddictConstants.Destinations.IdentityToken));
            }

            var claimsIdentity = new ClaimsIdentity(claims, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Set requested scopes (this is not done automatically)
            var scopes = request.GetScopes();
            if (!scopes.Contains(OpenIddictConstants.Scopes.OfflineAccess))
            {
                var scopesList = scopes.ToList();
                scopesList.Add(OpenIddictConstants.Scopes.OfflineAccess);
                claimsPrincipal.SetScopes(scopes);
            } else {
                claimsPrincipal.SetScopes(scopes);
            }

            // Signing in with the OpenIddict authentiction scheme trigger OpenIddict to issue a code (which can be exchanged for an access token)
            return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
        
        [HttpPost("connect/token")]
        public async Task<IActionResult> Exchange()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                          throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            ClaimsPrincipal claimsPrincipal;

            if (request.IsClientCredentialsGrantType())
            {
                // Note: the client credentials are automatically validated by OpenIddict:
                // if client_id or client_secret are invalid, this action won't be invoked.

                var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                // Subject (sub) is a required field, we use the client id as the subject identifier here.
                identity.AddClaim(OpenIddictConstants.Claims.Subject, request.ClientId ?? throw new InvalidOperationException());
                identity.AddClaim(ClaimTypes.Role, "User", OpenIddictConstants.Destinations.AccessToken);

                // Add some claim, don't forget to add destination otherwise it won't be added to the access token.

                claimsPrincipal = new ClaimsPrincipal(identity);

                claimsPrincipal.SetScopes(request.GetScopes());
            }

            else if (request.IsAuthorizationCodeGrantType())
            {
                // Retrieve the claims principal stored in the authorization code
                claimsPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
            }
            
            else if (request.IsRefreshTokenGrantType())
            {
                // Retrieve the claims principal stored in the refresh token.
                claimsPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
                if (!claimsPrincipal.HasScope(OpenIddictConstants.Scopes.OfflineAccess))
                {
                    var currentScopes = claimsPrincipal.GetScopes().ToList();
                    currentScopes.Add(OpenIddictConstants.Scopes.OfflineAccess);
                    claimsPrincipal.SetScopes(currentScopes);
                }
            }

            else
            {
                throw new InvalidOperationException("The specified grant type is not supported.");
            }

            // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
            return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
        
        [Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet("connect/userinfo")]
        public async Task<IActionResult> Userinfo()
        {
            var claimsPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;

            return Ok(new
            {
                Name = claimsPrincipal.GetClaim(OpenIddictConstants.Claims.Subject),
                Occupation = "Developer",
                Age = 43
            });
        }

        [HttpGet("connect/clear-cookies")]
        public IActionResult ClearCookies()
        {
             foreach (var cookie in Request.Cookies.Keys) {
                Response.Cookies.Delete(cookie);
             }
             return Ok();
        }
    }
}