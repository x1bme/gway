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
        title="AOV"
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
    valveid: 5768,
    aovvalvetype: 0,
    nominalstroke: 6.5,
    onoff: 1,
    seatdiameter: 5.512
  },
  {
    valveid: 5769,
    aovvalvetype: 1,
    nominalstroke: 1.12,
    onoff: 1,
    seatdiameter: 1.57
  },
  {
    valveid: 5770,
    aovvalvetype: 0,
    nominalstroke: 0.5,
    onoff: 1,
    seatdiameter: 0.5
  },
  {
    valveid: 5771,
    aovvalvetype: 1,
    nominalstroke: 2.01,
    onoff: 1,
    seatdiameter: 1.73
  },
  {
    valveid: 5772,
    aovvalvetype: 0,
    nominalstroke: 1.5,
    onoff: 0,
    seatdiameter: 3.54
  },
  {
    valveid: 5773,
    aovvalvetype: 0,
    nominalstroke: 1.12,
    onoff: 1,
    seatdiameter: 2.08
  },
];
const columns = [
  {
    name: 'name',
    required: true,
    label: 'ValveID',
    align: 'left',
    field: 'valveid',
    sortable: true
  },
  {name: 'aovvalvetype', align: 'center', label: 'AovValveType', field: 'aovvalvetype', sortable: true},
  {name: 'nominalstroke', label: 'NominalStroke', field: 'nominalstroke', sortable: true},
  {name: 'onoff', label: 'OnOff', field: 'onoff'},
  {name: 'seatdiameter', label: 'SeatDiameter', field: 'seatdiameter'}
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
