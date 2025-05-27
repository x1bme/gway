<template>
    <span>
            <!-- <q-hierarchy square id="test" :columns="columns" :data="data" classes="bg-indigo-8 text-white"> -->
        <q-hierarchy square id="test" :columns="columns" :data="data">
          <template v-slot:body="props">
            <td data-th="Name">
              <div v-bind:style="props.setPadding(props.item)"
                   :class="props.iconName(props.item)!='done'?'q-pl-lg':''">
                <q-btn @click="props.toggle(props.item)" v-if="props.iconName(props.item)!='done'"
                       :icon="props.iconName(props.item)" flat
                       dense>
                </q-btn>
                <span class="q-ml-sm">{{ props.item.label }}</span>
              </div>
            </td>
            <td class="text-center">{{ props.item.description }}</td>
            <td class="text-left">
              <q-chip clickable @click="toggleText" color="green" v-if="props.item.note === 'Online' || props.item.note === 'Enabled'" square size="sm" class="text-white">
                {{ props.item.note }}
                      <!--
                      {{text}}
                      -->
              </q-chip>
              <q-chip clickable @click="toggleText" color="orange" v-else-if="props.item.note === 'Standby'" square size="sm" class="text-white">
                {{ props.item.note }}
                      <!--
                      {{text}}
                      -->
              </q-chip>
              <q-chip clickable @click="toggleText" color="red" v-else="props.item.note" square size="sm" class="text-white">
                {{ props.item.note }}
                      <!--
                      {{text}}
                      -->
              </q-chip>
            </td>
          </template>
        </q-hierarchy>
    </span>
</template>

<script>
import {defineComponent} from 'vue'


const columns = [
  {
    name: 'label',
    required: true,
    label: 'Valve Network',
    align: 'left',
    field: 'label',
    // (optional) tell QHierarchy you want this column sortable
    sortable: true,
    // If you want different sorting icon
    filterable: true
  },
  {
    name: 'Description',
    label: 'Description',
    sortable: true,
    field: 'description',
    align: 'center',
    filterable: false
  },
  {
    name: 'note',
    label: 'Status',
    sortable: true,
    field: 'note',
    align: 'left',
    filterable: false
  }
];
const data = [
  {
    label: "Valve 3JL",
    description: "Network for MOV 3JL",
    note: "Online",
    // id: 1,
    children: [
      // {
      //   label: "DAU System 156",
      //   description: "Data Acquisition Unit System 156",
      //   note: "Active",
      //   children: [
      //     {
      //       label: "DAU 156A @ MOV",
      //       description: "Located on MOV 3JL",
      //       note: "Enabled",
      //       // id: 4
      //     },
      //     {
      //       label: "DAU 156B @ MCC",
      //       description: "Located on MCC 19V",
      //       note: "Enabled",
      //       // id: 5
      //     }
      //   ],
      // },
            {
                    label: "DAU@Valve",
                    description: "DAU 156A at MOV 3JL",
                    note: "Online",
            },
            {
                    label: "DAU@Remote",
                    description: "DAU 156B at MCC 19V",
                    note: "Online",
            }
    ],
  },
  {
    label: "Valve 2JL",
    description: "Network for MOV 2JL",
    note: "Online",
    // id: 1,
    children: [
      //{
      //  label: "DAU System 829",
      //  description: "Data Acquisition Unit System 829",
      //  note: "Active",
      //  children: [
      //    {
      //      label: "DAU 829A @ MOV",
      //      description: "Located on MOV 2JL",
      //      note: "Disabled",
      //      // id: 4
      //    },
      //    {
      //      label: "DAU 829B @ MCC",
      //      description: "Located on MCC 18V",
      //      note: "Enabled",
      //      // id: 5
      //    }
      //  ],
      //},
            {
                    label: "DAU@Valve",
                    description: "DAU 829A at MOV 2JL",
                    note: "Standby",
            },
            {
                    label: "DAU@Remote",
                    description: "DAU 829B at MCC 18V",
                    note: "Online",
            },
    ],
  },
        {
                label: "Valve 2KL",
                description: "Network for MOV 2KL",
                note: "Offline",
                // id: 1,
                children: [
                        //{
                        //        label: "DAU System 153",
                        //        description: "Data Acquisition Unit System 153",
                        //        note: "Inactive",
                        //        children: [
                        //                {
                        //                        label: "DAU 153A @ MOV",
                        //                        description: "Located on MOV 2KL",
                        //                        note: "Disabled",
                        //                        // id: 4
                        //                },
                        //                {
                        //                        label: "DAU 153B @ MCC",
                        //                        description: "Located on MCC 9JL",
                        //                        note: "Disabled",
                        //                        // id: 5
                        //                }
                        //        ],
                        //},
            {
                    label: "DAU@Valve",
                    description: "DAU 153A at MOV 2KL",
                    note: "Offline",
            },
            {
                    label: "DAU@Remote",
                    description: "DAU 153B at MCC 9JL",
                    note: "Offline",
            }
                ],
        },
        {
                label: "Valve 5KL",
                description: "Network for MOV 5KL",
                note: "Standby",
                // id: 1,
                children: [
                        //{
                        //        label: "DAU System 153",
                        //        description: "Data Acquisition Unit System 153",
                        //        note: "Inactive",
                        //        children: [
                        //                {
                        //                        label: "DAU 153A @ MOV",
                        //                        description: "Located on MOV 2KL",
                        //                        note: "Disabled",
                        //                        // id: 4
                        //                },
                        //                {
                        //                        label: "DAU 153B @ MCC",
                        //                        description: "Located on MCC 9JL",
                        //                        note: "Disabled",
                        //                        // id: 5
                        //                }
                        //        ],
                        //},
            {
                    label: "DAU@Valve",
                    description: "DAU 623A at MOV 5KL",
                    note: "Standby",
            },
            {
                    label: "DAU@Remote",
                    description: "DAU 623B at MCC 33V",
                    note: "Standby",
            }
                ],
        }

];

export default defineComponent({
  name: "ValveCustomHierarchy",
  setup() {
    return {
      columns,
      data
    }
  },
        methods:{
                toggleText(){
                         this.props.item.note= "new";
                }
        },
        data() {
                return {
                        text: 'Inital Text'
                };
        }
})
</script>

<style scoped>

</style>
