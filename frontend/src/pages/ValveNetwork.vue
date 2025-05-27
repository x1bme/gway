<template>
  <q-page class="q-pa-sm">

          <!--
    <q-card class="no-shadow" bordered>
      <q-card-section>
        <div class="text-h6 text-indigo-8">
          Gemini Nodes
        </div>
        <div class="text-subtitle2">
          A simple Tree Collapsed/Expanded Table
        </div>
      </q-card-section>

      <q-separator></q-separator>
      <q-card-section class="q-pa-none">
        <gemini-simple-hierarchy></gemini-simple-hierarchy>
      </q-card-section>
    </q-card>
          -->

    <q-card class="q-mt-sm no-shadow" bordered>
      <q-card-section>
              
              <!-- <div class="text-h6 text-indigo-8"> -->
        <div class="text-h6">
                Valve Networks
        </div>
        <div class="text-subtitle2">
                <!--
                The networks below are all of the networks that Gemini Server PID 158 is currently connected to. Green status means active/enabled, and the red status means inactive/disabled.
                -->
                Provided below are all of the Gemini Networks currently connected to this instance of Loom (Gemini Server PID 158). Each Gemini Network is titled by the valve that is connected to that specific network. In this context, "Valve Network" is synonymous with "Gemini Network". 

        </div>
        <hr>
        <div class="text-h7">

                <u>Key:</u>
        </div>
        <ul>
                <li style="color: green;"><b><u>Online</u>:</b> online, normal operation</li>
                <li style="color: orange;"><b><u>Standby</u>:</b> online, but inactive or disabled</li>
                <li style="color: red;"><b><u>Offline</u>:</b> offline, attention required</li>
        </ul>
      </q-card-section>
      <q-separator></q-separator>

      <q-card-section class="q-pa-none">
        <valve-custom-hierarchy></valve-custom-hierarchy>
      </q-card-section>
    </q-card>

  </q-page>
</template>

<script>
import {defineComponent, defineAsyncComponent} from 'vue'

export default defineComponent({
  name: "ValveNetwork",
  components: {
    ValveSimpleHierarchy: defineAsyncComponent(() => import('components/tree-table/ValveSimpleHierarchy.vue')),
    ValveCustomHierarchy: defineAsyncComponent(() => import('components/tree-table/ValveCustomHierarchy.vue'))
  }
})
</script>

<style scoped>
 hr {
    border: none;
    height: 1px;
    background-color: #333; /* Change color as needed */
    width: 100%; /* Full-width */
    margin: 10px 0; /* Adds vertical spacing before and after
 the divider */
 }
</style>
