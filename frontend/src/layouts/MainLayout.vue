<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          @click="toggleLeftDrawer"
          icon="menu"
          aria-label="Menu"
        />
        <q-toolbar-title>
         Loom, v1.5 (updated Jul 22 2024)
        </q-toolbar-title>
        <q-space/>
        <div class="q-gutter-sm row items-center no-wrap">
                    <q-btn round dense flat color="white" :icon="quasar.fullscreen.isActive ? 'fullscreen_exit' : 'fullscreen'"
                           @click="quasar.fullscreen.toggle()"
                           v-if="quasar.screen.gt.sm">
                    </q-btn>
        </div>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      class="bg-primary text-white"
    >
      <q-list>
        <q-item to="/" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="home"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Loom Home</q-item-label>
          </q-item-section>
        </q-item>

        <q-expansion-item
          icon="list"
          label="Valve Management"
        >
          <q-item to="/Valves" class="q-ml-xl" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="water"/>
          </q-item-section>
            <q-item-section>
              <q-item-label>Valves</q-item-label>
            </q-item-section>
          </q-item>

          <q-item to="/Daus" class="q-ml-xl" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="router"/>
          </q-item-section>
            <q-item-section>
              <q-item-label>Daus</q-item-label>
            </q-item-section>
          </q-item>

          <q-item to="/ValveLogs" class="q-ml-xl" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="article"/>
          </q-item-section>
            <q-item-section>
              <q-item-label>Valve Logs</q-item-label>
            </q-item-section>
          </q-item>
          <!--
          <q-expansion-item
            :header-inset-level="0.85"
            label="Valve Configuration"
          >
            <q-item class="q-ml-xl" style="margin-left: 55px  !important;" active-class="q-item-no-link-highlighting">
             <q-item-section avatar>
               <q-icon name="manufacturing"/>
             </q-item-section>
              <q-item-section>
                <q-item-label>Valve Networks</q-item-label>
              </q-item-section>
            </q-item>

            <q-expansion-item
              :header-inset-level="1"
              label="Level 2.2"
            >
              <q-item style="margin-left: 65px  !important;" active-class="q-item-no-link-highlighting">
                <q-item-section>
                  <q-item-label>Level 2.2.1</q-item-label>
                </q-item-section>
              </q-item>
              <q-item style="margin-left: 65px  !important;" active-class="q-item-no-link-highlighting">
                <q-item-section>
                  <q-item-label>Level 2.2.2</q-item-label>
                </q-item-section>
              </q-item>
            </q-expansion-item>
          </q-expansion-item>
          -->
        </q-expansion-item>
        <!--
        <q-item to="/Dashboard2" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="dashboard"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>CRM Dashboard</q-item-label>
          </q-item-section>
        </q-item> 
        -->

        <!--
        <q-expansion-item
          icon="pages"
          label="Pages"
        >
          <q-list class="q-pl-lg">
            <q-item to="/Login-1" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="email"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Login-1</q-item-label>
              </q-item-section>
            </q-item>
            <q-item to="/Lock" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="lock"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Lock Screen</q-item-label>
              </q-item-section>
            </q-item>
            <q-item to="/Lock-2" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="lock"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Lock Screen - 2</q-item-label>
              </q-item-section>
            </q-item>
            <q-item to="/Pricing" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="list"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Pricing</q-item-label>
              </q-item-section>
            </q-item>
            <q-item-label header class="text-weight-bolder text-white">Generic</q-item-label>
            <q-item to="/Profile" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="person"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>User Profile</q-item-label>
              </q-item-section>
            </q-item>
            <q-item to="/Maintenance" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="settings"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Maintenance</q-item-label>
              </q-item-section>
            </q-item>
          </q-list>
        </q-expansion-item>
        -->
        

        <!--
        <q-expansion-item
          icon="map"
          label="Maps"
        >
          <q-list class="q-pl-lg">
            <q-item to="/Map" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="map"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Map</q-item-label>
              </q-item-section>
            </q-item>
            <q-item to="/MapMarker" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="location_on"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Map Marker</q-item-label>
              </q-item-section>
            </q-item>
            <q-item to="/StreetView" active-class="q-item-no-link-highlighting">
              <q-item-section avatar>
                <q-icon name="streetview"/>
              </q-item-section>
              <q-item-section>
                <q-item-label>Street View</q-item-label>
              </q-item-section>
            </q-item>
          </q-list>
        </q-expansion-item>
        -->

        <!--
        <q-item to="/Mail" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="email"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Loom (User?) Mail</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/directory" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="card_giftcard"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Directory</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/TreeTable" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="list"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>TreeTable</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/Charts" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="insert_chart"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Loom Statistics</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/Footer" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="info"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Footer</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/CardHeader" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="card_giftcard"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Card Header</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/Cards" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="card_giftcard"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Cards</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/Tables" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="table_chart"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Loom Statistics Tables</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/Contact" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="person"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Loom Contact</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--
        <q-item to="/Checkout" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="check_circle_outline"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Checkout</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--        not completed-->
        <!--
        <q-item to="/Calendar" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="date_range"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Loom (Upgrades) Calendar</q-item-label>
          </q-item-section>
        </q-item>
        -->

        <!--        not completed-->
        <!--        <q-item to="/Taskboard" active-class="q-item-no-link-highlighting">-->
        <!--          <q-item-section avatar>-->
        <!--            <q-icon name="done"/>-->
        <!--          </q-item-section>-->
        <!--          <q-item-section>-->
        <!--            <q-item-label>Taskboard</q-item-label>-->
        <!--          </q-item-section>-->
        <!--        </q-item>-->

        <!--
        <q-item to="/Pagination" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="date_range"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Pagination</q-item-label>
          </q-item-section>
        </q-item>
        -->


        <q-item to="/Web" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="web"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Web Interface Settings</q-item-label>
          </q-item-section>
        </q-item>

        <q-item to="/DatabaseInterface" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="storage"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Database Interface</q-item-label>
          </q-item-section>
        </q-item>

        <q-item to="/Construction" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="wysiwyg"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>VOTES Infinity Integration</q-item-label>
          </q-item-section>
        </q-item>

        <q-item to="/Flowing" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="cloud"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Gemini Network</q-item-label>
          </q-item-section>
        </q-item>

        <q-item to="/Construction" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="security"/>
          </q-item-section>
          <q-item-section>
                  <q-item-label>Security</q-item-label>
          </q-item-section>
        </q-item>
        <!-- Use /Profile in future -->
        <q-item to="/ProfileSettings" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="manage_accounts"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>User Settings</q-item-label>
          </q-item-section>
        </q-item>
        <q-item to="/logout" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="logout"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>Logout</q-item-label>
          </q-item-section>
        </q-item>
        <q-item to="/storetest" active-class="q-item-no-link-highlighting">
          <q-item-section avatar>
            <q-icon name="store"/>
          </q-item-section>
          <q-item-section>
            <q-item-label>store</q-item-label>
          </q-item-section>
        </q-item>

        <!--
        <q-expansion-item
          icon="valve"
          label="Valve Management"
        >
          <q-item class="q-ml-xl" active-class="q-item-no-link-highlighting">
            <q-item-section>
              <q-item-label>Configuration</q-item-label>
            </q-item-section>
          </q-item>
          <q-expansion-item
            :header-inset-level="0.85"
            label="Level 2"
          >
            <q-item class="q-ml-xl" style="margin-left: 55px  !important;" active-class="q-item-no-link-highlighting">
              <q-item-section>
                <q-item-label>Level 2.1</q-item-label>
              </q-item-section>
            </q-item>
            <q-expansion-item
              :header-inset-level="1"
              label="Level 2.2"
            >
              <q-item style="margin-left: 65px  !important;" active-class="q-item-no-link-highlighting">
                <q-item-section>
                  <q-item-label>Level 2.2.1</q-item-label>
                </q-item-section>
              </q-item>
              <q-item style="margin-left: 65px  !important;" active-class="q-item-no-link-highlighting">
                <q-item-section>
                  <q-item-label>Level 2.2.2</q-item-label>
                </q-item-section>
              </q-item>
            </q-expansion-item>
          </q-expansion-item>
        </q-expansion-item>
        -->

      </q-list>
    </q-drawer>

    <q-page-container class="bg-grey-2">
      <router-view/>
    </q-page-container>
  </q-layout>
</template>

<script>

import {defineComponent, ref} from 'vue'
import {useQuasar} from "quasar";

export default defineComponent({
  name: 'MainLayout',


  setup() {
    const leftDrawerOpen = ref(false)
    const quasar = useQuasar()

    return {
      quasar,
      leftDrawerOpen,
      toggleLeftDrawer() {
        leftDrawerOpen.value = !leftDrawerOpen.value
      }
    }
  }
})
</script>

<style>

/* FONT AWESOME GENERIC BEAT */
.fa-beat {
  animation: fa-beat 5s ease infinite;
}

@keyframes fa-beat {
  0% {
    transform: scale(1);
  }
  5% {
    transform: scale(1.25);
  }
  20% {
    transform: scale(1);
  }
  30% {
    transform: scale(1);
  }
  35% {
    transform: scale(1.25);
  }
  50% {
    transform: scale(1);
  }
  55% {
    transform: scale(1.25);
  }
  70% {
    transform: scale(1);
  }
}

</style>
