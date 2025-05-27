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
              <q-chip color="lime-9" v-if="props.item.note === 'Active' || props.item.note === 'Enabled'" square size="sm" class="text-white">
                {{ props.item.note }}
              </q-chip>
              <q-chip color="red" v-else="props.item.note" square size="sm" class="text-white">
                {{ props.item.note }}
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
    label: 'Gemini Network',
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
    label: "Gemini Network 1",
    description: "Gemini Network 1",
    note: "Active",
    // id: 1,
    children: [
      {
        label: "DAU System 156",
        description: "Data Acquisition Unit System 156",
        note: "Active",
        children: [
          {
            label: "DAU 156A @ MOV",
            description: "Located on MOV 3JL",
            note: "Enabled",
            // id: 4
          },
          {
            label: "DAU 156B @ MCC",
            description: "Located on MCC 19V",
            note: "Enabled",
            // id: 5
          }
        ],
      },
            {
                    label: "Gemini Server 158",
                    description: "Gemini Server, PID 158 ",
                    note: "Active",
            }
    ],
  },
  {
    label: "Gemini Network 2",
    description: "Gemini Network 2",
    note: "Active",
    // id: 1,
    children: [
      {
        label: "DAU System 829",
        description: "Data Acquisition Unit System 829",
        note: "Active",
        children: [
          {
            label: "DAU 829A @ MOV",
            description: "Located on MOV 2JL",
            note: "Disabled",
            // id: 4
          },
          {
            label: "DAU 829B @ MCC",
            description: "Located on MCC 18V",
            note: "Enabled",
            // id: 5
          }
        ],
      },
            {
                    label: "Gemini Server 158",
                    description: "Gemini Server, PID 158 ",
                    note: "Active",
            }
    ],
  },
        {
                label: "Gemini Network 3",
                description: "Gemini Network 3",
                note: "Active",
                // id: 1,
                children: [
                        {
                                label: "DAU System 153",
                                description: "Data Acquisition Unit System 153",
                                note: "Inactive",
                                children: [
                                        {
                                                label: "DAU 153A @ MOV",
                                                description: "Located on MOV 2KL",
                                                note: "Disabled",
                                                // id: 4
                                        },
                                        {
                                                label: "DAU 153B @ MCC",
                                                description: "Located on MCC 9JL",
                                                note: "Disabled",
                                                // id: 5
                                        }
                                ],
                        },
            {
                    label: "Gemini Server 158",
                    description: "Gemini Server, PID 158",
                    note: "Active",
            }
                ],
        }

];

export default defineComponent({
  name: "GeminiCustomHierarchy",
  setup() {
    return {
      columns,
      data
    }
  }
})
</script>

<style scoped>
</style>
