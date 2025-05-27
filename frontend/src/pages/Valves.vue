<template>
  <q-page padding>
    <!-- Search bar -->
    <q-input
      v-model="searchQuery"
      filled
      label="Search by Tag #"
      class="q-mb-md"
    >
      <template v-slot:append>
        <q-icon name="search" />
      </template>
    </q-input>

    <div class="q-gutter-y-md">
      <q-card v-for="(item, index) in filteredItems" :key="index" flat bordered>
        <q-card-section>
          <div class="row items-center q-gutter-x-md">
            <!-- Image with upload functionality and status border -->
            <div class="col-12 col-sm-3">
              <div :class="['image-container', `status-${item.status}`]">
                <q-img
                  :src="item.imageUrl || defaultImage"
                  style="height: 200px; width: 200px"
                />
              </div>
              <q-file
                v-model="item.file"
                label="Upload Image"
                style="max-width: 200px"
                class="q-mt-sm"
                @update:model-value="onFileSelected(index)"
              >
                <template v-slot:append>
                  <q-icon name="attach_file" />
                </template>
              </q-file>
            </div>

            <!-- Title and Description -->
            <div class="col-12 col-sm-6">
              <q-input
                v-model="item.title"
                label="Tag #"
                class="q-mb-sm"
              />
              <q-input
                v-model="item.description"
                type="textarea"
                label="Description"
                rows="3"
              />
            </div>

            <!-- Status selector -->
            <div class="col-12 col-sm-3">
              <q-select
                v-model="item.status"
                :options="statusOptions"
                label="Status"
                emit-value
                map-options
              />
            </div>
          </div>
        </q-card-section>
      </q-card>
    </div>
  </q-page>
</template>

<script>
import { ref, computed } from 'vue'

export default {
  setup() {
    const defaultImage = '/images/default-image.jpg' // Replace with your default image path

    const items = ref([
      { title: 'MOV 3JL', imageUrl: '../src/assets/gatevalve.jpg', description: 'Gate Valve', status: 'online', file: null },
      { title: 'MOV 2JL', imageUrl: '../src/assets/gatevalve.jpg', description: 'Gate Valve', status: 'online', file: null },
      { title: 'MOV 2KL', imageUrl: '../src/assets/sentinelvalve.jpg', description: 'Sentinel Valve', status: 'offline', file: null },
      { title: 'MOV 5KL', imageUrl: '../src/assets/globevalve.jpg', description: 'Globe Valve', status: 'standby', file: null },
    ])

    const searchQuery = ref('')

    const statusOptions = [
      { label: 'Online', value: 'online' },
      { label: 'Standby', value: 'standby' },
      { label: 'Offline', value: 'offline' },
    ]

    const filteredItems = computed(() => {
      if (!searchQuery.value) return items.value
      return items.value.filter(item => 
        item.title.toLowerCase().includes(searchQuery.value.toLowerCase())
      )
    })

    const onFileSelected = (index) => {
      const item = items.value[index]
      if (item.file) {
        const reader = new FileReader()
        reader.onload = (e) => {
          item.imageUrl = e.target.result
        }
        reader.readAsDataURL(item.file)
      } else {
        item.imageUrl = null
      }
    }

    return {
      items,
      defaultImage,
      onFileSelected,
      searchQuery,
      filteredItems,
      statusOptions
    }
  }
}
</script>

<style scoped>
.image-container {
  border: 4px solid transparent;
  display: inline-block;
  overflow: hidden;
}

.image-container .q-img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.status-online {
  border-color: #21BA45; /* Green */
}

.status-standby {
  border-color: #F2C037; /* Orange */
}

.status-offline {
  border-color: #C10015; /* Red */
}
</style>
