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
                Gemini Network
        </div>
        <div class="text-subtitle2">
                The networks below are all of the networks that Gemini Server PID 158 is currently connected to. Green status means active/enabled, and the red status means inactive/disabled.
        </div>
      </q-card-section>
      <q-separator></q-separator>

      <q-card-section class="q-pa-none">
        <gemini-custom-hierarchy></gemini-custom-hierarchy>
      </q-card-section>
    </q-card>

  </q-page>
</template>

<script>
import {defineComponent, defineAsyncComponent} from 'vue'

export default defineComponent({
  name: "GeminiNetwork",
  components: {
    GeminiSimpleHierarchy: defineAsyncComponent(() => import('components/tree-table/GeminiSimpleHierarchy.vue')),
    GeminiCustomHierarchy: defineAsyncComponent(() => import('components/tree-table/GeminiCustomHierarchy.vue'))
  }
})
</script>

<style scoped>
</style>
