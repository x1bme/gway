<template>
  <q-page class="q-pa-sm">

    <a-o-v-table-basic></a-o-v-table-basic>
    <m-o-v-table-basic></m-o-v-table-basic>
    <sensor-calibration-table-basic></sensor-calibration-table-basic>

    <!--
    <table-actions class="q-mt-lg"></table-actions>

    <table-dark-mode class="q-mt-lg"></table-dark-mode>

    <table-progress class="q-mt-lg"></table-progress>

    <table-custom-grid class="q-mt-lg"></table-custom-grid>
    -->

  </q-page>
</template>

<script>
import {defineComponent, defineAsyncComponent} from 'vue';

export default defineComponent({
  name: "DatabaseInterface",
  components: {
    AOVTableBasic: defineAsyncComponent(() => import('components/tables/AOVTableBasic.vue')),
    MOVTableBasic: defineAsyncComponent(() => import('components/tables/MOVTableBasic.vue')),
    SensorCalibrationTableBasic: defineAsyncComponent(() => import('components/tables/SensorCalibrationTableBasic.vue'))
  },
})
</script>

<style>

</style>
