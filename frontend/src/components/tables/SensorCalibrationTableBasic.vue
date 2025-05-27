<!-- 

ValveID
AovValveType
NominalStroke
OnOff
SeatDiameter

-->

<template>
  <q-card class="no-shadow" bordered>
    <q-card-section>
      <div class="text-h6 text-grey-8">
              MSSQL (server ip: 192.168.1.32, port: 1433)
      </div>
    </q-card-section>
    <q-separator></q-separator>
    <q-card-section class="q-pa-none">
      <q-table square class="no-shadow"
        title="SensorCalibration"
        :rows="data"
        :columns="columns"
        row-key="name"
        :filter="filter"
      >
        <template v-slot:top-right>
          <q-input v-if="show_filter" filled borderless dense debounce="300" v-model="filter" placeholder="Search">
            <template v-slot:append>
              <q-icon name="search"/>
            </template>
          </q-input>

          <q-btn class="q-ml-sm" icon="filter_list" @click="show_filter=!show_filter" flat/>
        </template>
      </q-table>
    </q-card-section>
  </q-card>
</template>

<script>
import {defineComponent, ref} from 'vue'


const data = [
  {
    sensorid: 794,
    sensorcalibrationid: 1120,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 93.029,
    sensitivityaspect1: 17
  },
  {
    sensorid: 795,
    sensorcalibrationid: 1121,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 518.578,
    sensitivityaspect1: 17
  },
  {
    sensorid: 796,
    sensorcalibrationid: 1122,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 19.225,
    sensitivityaspect1: 17
  },
  {
    sensorid: 797,
    sensorcalibrationid: 1123,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 8.73,
    sensitivityaspect1: 17
  },
  {
    sensorid: 798,
    sensorcalibrationid: 1124,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 1.33,
    sensitivityaspect1: 17
  },
  {
    sensorid: 799,
    sensorcalibrationid: 1125,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 4.23,
    sensitivityaspect1: 18
  },
  {
    sensorid: 800,
    sensorcalibrationid: 1126,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 13.83,
    sensitivityaspect1: 17
  },
  {
    sensorid: 801,
    sensorcalibrationid: 1127,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 288.11,
    sensitivityaspect1: 17
  },
  {
    sensorid: 802,
    sensorcalibrationid: 1128,
    scalingfactor1: 1,
    scalingunit1: 2,
    scalingvalue1: 332.12,
    sensitivityaspect1: 17
  },
];
const columns = [
  {
    name: 'name',
    required: true,
    label: 'SensorID',
    align: 'left',
    field: 'sensorid',
    sortable: true
  },
  {name: 'sensorcalibrationid', align: 'center', label: 'SensorCalibrationID', field: 'sensorcalibrationid', sortable: true},
  {name: 'scalingfactor1', label: 'ScalingFactor', field: 'scalingfactor1', sortable: true},
  {name: 'scalingunit1', label: 'ScalingUnit1', field: 'scalingunit1'},
  {name: 'scalingvalue1', label: 'ScalingValue1', field: 'scalingvalue1'},
  {name: 'sensitivityaspect1', label: 'SensitivityAspect1', field: 'sensitivityaspect1'}
];

export default defineComponent({
  name: "AOVTableBasic",
  setup() {
    const show_filter = ref(false)

    return {
      filter: ref(''),
      show_filter,
      data,
      columns
    }
  }
})
</script>

<style scoped>

</style>
