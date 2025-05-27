<!-- 

ValveID
MovValveType
MovStemType
StrokeLength
SpringPack

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
        title="MOV"
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
    valveid: 3188,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 10,
    springpack: '0301-109'
  },
  {
    valveid: 3189,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 10,
    springpack: '0301-109'
  },
  {
    valveid: 3190,
    movvalvetype: 4,
    movstemtype: 3,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3192,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3193,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3194,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3195,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3196,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3197,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3198,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3199,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3200,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3201,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3202,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3203,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3204,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3205,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3206,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  },
  {
    valveid: 3206,
    movvalvetype: 4,
    movstemtype: 2,
    strokelength: 30,
    springpack: '0501-183'
  }
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
  {name: 'movvalvetype', align: 'center', label: 'MovValveType', field: 'movvalvetype', sortable: true},
  {name: 'movstemtype', label: 'MovStemType', field: 'movstemtype', sortable: true},
  {name: 'strokelength', label: 'StrokeLength', field: 'StrokeLength'},
  {name: 'springpack', label: 'SpringPack', field: 'springpack'}
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
