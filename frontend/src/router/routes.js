const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {path: '', component: () => import('pages/Home.vue'), meta: { requiresAuth: true }},
      {path: 'login', component: () => import('pages/LoginPage.vue')},
      {path: 'logout', component: () => import('pages/LogoutPage.vue')},
      {path: 'Callback', component: () => import('pages/Callback.vue')},
      {path: 'Construction', component: () => import('pages/Construction.vue'), meta: { requiresAuth: true }},
      {path: 'Web', component: () => import('pages/Web.vue'), meta: { requiresAuth: true }},
      {path: 'DatabaseInterface', component: () => import('pages/DatabaseInterface.vue'), meta: { requiresAuth: true }},
      {path: 'UserSettings', component: () => import('pages/UserSettings.vue'), meta: { requiresAuth: true }},
      {path: 'Flowing', component: () => import('pages/Flowing.vue'), meta: { requiresAuth: true }},
      {path: 'ValveNetwork', component: () => import('pages/ValveNetwork.vue'), meta: { requiresAuth: true }},
      {path: 'ValveLogs', component: () => import('pages/ValveLogs.vue'), meta: { requiresAuth: true }},
      {path: 'ProfileSettings', component: () => import('pages/ProfileSettings.vue'), meta: { requiresAuth: true }},
      {path: 'Valves', component: () => import('pages/ValveDisplay.vue'), meta: { requiresAuth: true }},
      {path: 'Daus', component: () => import('pages/DauDisplay.vue'), meta: { requiresAuth: true }},
      {path: 'ValveConfigs', component: () => import('pages/ValveConfigurations.vue'), meta: { requiresAuth: true }},

      // Not completed yet
      // {path: '/Taskboard', component: () => import('pages/TaskBoard.vue')},
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
