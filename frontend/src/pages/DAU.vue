<template>
  <q-page class="q-pa-sm">
    <div>
      <q-card class="no-border no-shadow bg-transparent">
        <q-card-section class="q-pa-sm">
          <q-input rounded v-model="search1" outlined placeholder="Search Valve (Enter Tag #)">
            <template v-slot:append>
              <q-icon v-if="search1 === ''" name="search1"/>
              <q-icon v-else name="clear" class="cursor-pointer" @click="search1 = ''"/>
            </template>
          </q-input>
          <!--
          <q-input rounded v-model="search2" outlined placeholder="Search MOV (Enter Tag #)">
            <template v-slot:append>
              <q-icon v-if="search2 === ''" name="search2"/>
              <q-icon v-else name="clear" class="cursor-pointer" @click="search2 = ''"/>
            </template>
          </q-input>
          <q-input rounded v-model="search3" outlined placeholder="Search MCC (Enter Tag #)">
            <template v-slot:append>
              <q-icon v-if="search3 === ''" name="search3"/>
              <q-icon v-else name="clear" class="cursor-pointer" @click="search3 = ''"/>
            </template>
          </q-input>
          -->
        </q-card-section>
      </q-card>
    </div>
    <div class="row q-col-gutter-sm ">
      <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" v-for="item, item_index in data">
        <card-product :data="item"></card-product>
      </div>
    </div>
  </q-page>
</template>

<script>
import {defineComponent, defineAsyncComponent} from 'vue';
import {ref} from 'vue';

// DAU 156A MOV 3JL
// DAU 156B MCC 19V

// DAU 829A MOV 2JL
// DAU 829B MCC 18V

// DAU 153A MOV 2KL
// DAU 153B MCC 9JL
const data = [
  //{
  //  title: 'DAU 156A',
  //  caption: 'DAU 156A at MOV 3JL',
  //  img: new URL("../assets/bbb.jpg", import.meta.url),
  //},
  //{
  //  title: 'DAU 829A',
  //  caption: 'DAU 829A at MOV 2JL',
  //  img: new URL("../assets/bbb.jpg", import.meta.url),
  //},
  //{
  //  title: 'DAU 156B',
  //  caption: 'DAU 156B at MCC 19V',
  //  img: new URL("../assets/bbb.jpg", import.meta.url),
  //},
  //{
  //  title: 'DAU 829B',
  //  caption: 'DAU 829B at MCC 18V',
  //  img: new URL("../assets/bbb.jpg", import.meta.url),
  //},
  {
    title: 'MOV 3JL',
    caption: 'MOV 3JL, Gate Valve',
    img: new URL("../assets/mov.jpg", import.meta.url),
  },
  {
    title: 'MOV 2JL',
    caption: 'MOV 2JL, Gate Valve',
    img: new URL("../assets/mov.jpg", import.meta.url),
  },
  //{
  //  title: 'MCC 19V',
  //  caption: 'MCC 19V, CENTERLINE® 2500 IEC low voltage',
  //  img: new URL("../assets/mcc.jpg", import.meta.url),
  //},
  //{
  //  title: 'MCC 18V',
  //  caption: 'MCC 18V, CENTERLINE® 2500 IEC low voltage',
  //  img: new URL("../assets/mcc.jpg", import.meta.url),
  //},
  //{
  //  title: 'DAU 153A',
  //  caption: 'DAU 153A at MOV 2KL',
  //  img: new URL("../assets/bbb.jpg", import.meta.url),
  //},
  //{
  //  title: 'DAU 153B',
  //  caption: 'DAU 153B at MCC 9JL',
  //  img: new URL("../assets/bbb.jpg", import.meta.url),
  //},
  //{
  //  title: 'MCC 9JL',
  //  caption: 'MCC 9JL, CENTERLINE® 2500 IEC low voltage',
  //  img: new URL("../assets/mcc.jpg", import.meta.url),
  //},
  {
    title: 'MOV 2KL',
    caption: 'MOV 2KL, Sentinel Valve',
    img: new URL("../assets/mov2.jpg", import.meta.url),
  },
  {
    title: 'MOV 5KL',
    caption: 'MOV 5KL, Globe Valve',
    img: new URL("../assets/mov3.jpg", import.meta.url),
  },
];

export default defineComponent({
  name: "ProductCatalogues",
  components: {CardProduct: defineAsyncComponent(() => import('components/cards/CardProduct.vue'))},
  setup() {
    const search = ref('');
    return {
      search,
      data
    }
  }
})
</script>

<style scoped>

</style>
