<template>
  <q-page padding class="bg-grey-1">
    <!-- Search bar -->
    <q-input
      v-model="searchQuery"
      filled
      label="Search by Valve Tag #"
      class="q-mb-md"
      bg-color="white"
    >
      <template v-slot:append>
        <q-icon name="search" />
      </template>
    </q-input>

    <div class="q-gutter-y-md">
      <q-card v-for="(valve, index) in filteredValves" :key="index" flat class="valve-card">
        <q-card-section>
          <div class="row items-center q-gutter-x-md">
            <!-- Valve Title with status border -->
            <div class="col-12 col-sm-4 col-md-3">
              <div :class="['title-border', `status-${valve.status}`]">
                <div class="text-h6">{{ valve.title }}</div>
              </div>
            </div>

            <!-- DAU Names -->
            <div class="col-12 col-sm-8 col-md-6">
              <div class="row q-col-gutter-sm">
                <div class="col-6">
                  <q-input v-model="valve.dauMovName" label="DAU@Valve" dense filled />
                </div>
                <div class="col-6">
                  <q-input v-model="valve.dauMccName" label="DAU@Remote" dense filled />
                </div>
              </div>
            </div>


            <!-- DAU Settings -->
            <div class="col-12">
              <div class="row q-col-gutter-md">
                <div class="col-12 col-md-6">
                  <q-card flat bordered :class="['bg-grey-2', getDauBorderClass(valve.dauMovStatus)]">
                    <q-card-section>
                      <div class="text-subtitle1">DAU@Valve</div>
                      <q-toggle 
                        v-model="valve.dauMovHeartbeatAlerts" 
                        :label="valve.dauMovHeartbeatAlerts ? 'Heartbeat Alerts' : 'Heartbeat Alerts (Disabled)'"
                        :class="{ 'text-grey': !valve.dauMovHeartbeatAlerts }"
                      />
                      <q-input v-model="valve.dauMovIp" label="IP Address" dense filled />
                      <q-input v-model="valve.dauMovLastHeartbeat" label="Last Heartbeat" dense filled readonly />
                      <div class="row q-col-gutter-sm">
                        <div class="col-6">
                          <q-input v-model="valve.dauMovLastCalibration" label="Last Calibration" dense filled readonly />
                        </div>
                        <div class="col-6">
                          <q-input v-model="valve.dauMovNextCalibration" label="Next Calibration" dense filled />
                        </div>
                      </div>
                    </q-card-section>
                  </q-card>
                </div>
                <div class="col-12 col-md-6">
                  <q-card flat bordered :class="['bg-grey-2', getDauBorderClass(valve.dauMccStatus)]">
                    <q-card-section>
                      <div class="text-subtitle1">DAU@Remote</div>
                      <q-toggle 
                        v-model="valve.dauMccHeartbeatAlerts" 
                        :label="valve.dauMccHeartbeatAlerts ? 'Heartbeat Alerts' : 'Heartbeat Alerts (Disabled)'"
                        :class="{ 'text-grey': !valve.dauMccHeartbeatAlerts }"
                      />
                      <q-input v-model="valve.dauMccIp" label="IP Address" dense filled />
                      <q-input v-model="valve.dauMccLastHeartbeat" label="Last Heartbeat" dense filled readonly />
                      <div class="row q-col-gutter-sm">
                        <div class="col-6">
                          <q-input v-model="valve.dauMccLastCalibration" label="Last Calibration" dense filled readonly />
                        </div>
                        <div class="col-6">
                          <q-input v-model="valve.dauMccNextCalibration" label="Next Calibration" dense filled />
                        </div>
                      </div>
                    </q-card-section>
                  </q-card>
                </div>
              </div>
            </div>

            <!-- Email Recipients -->
            <div class="col-12 q-mt-md">
              <q-input v-model="valve.emailRecipients" label="Email Recipients" type="textarea" rows="2" filled />
            </div>
            <!-- Export Button -->
            <div class="col-12 col-sm-12 col-md-12 text-right">
              <q-btn color="primary" label="Export Configuration" @click="exportConfig(valve)" />
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
    const searchQuery = ref('')

    const getDauBorderClass = (status) => {
      switch (status) {
        case 'online':
          return 'dau-border-online';
        case 'standby':
          return 'dau-border-standby';
        case 'offline':
          return 'dau-border-offline';
        default:
          return '';
      }
    }

    const valves = ref([
      {
        title: 'MOV 3JL',
        status: 'online',
        dauMovName: 'DAU 156A',
        dauMovStatus: 'online',
        dauMccName: 'DAU 156B',
        dauMccStatus: 'online',
        dauMovHeartbeatAlerts: true,
        dauMccHeartbeatAlerts: false,
        dauMovNextCalibration: '2024-08-15 09:00:00',
        dauMccNextCalibration: '2024-08-16 14:00:00',
        dauMovLastCalibration: '2024-07-15 09:00:00',
        dauMccLastCalibration: '2024-07-14 14:00:00',
        dauMovIp: '192.168.1.100',
        dauMccIp: '192.168.1.101',
        dauMovLastHeartbeat: '2024-07-20 10:30:00',
        dauMccLastHeartbeat: '2024-07-20 10:35:00',
        emailRecipients: 'hhua@cranevs.com'
      },
      {
        title: 'MOV 2JL',
        status: 'online',
        dauMovName: 'DAU 829A',
        dauMovStatus: 'standby',
        dauMccName: 'DAU 829B',
        dauMccStatus: 'online',
        dauMovHeartbeatAlerts: false,
        dauMccHeartbeatAlerts: true,
        dauMovNextCalibration: '2024-08-14 10:00:00',
        dauMccNextCalibration: '2024-08-15 15:00:00',
        dauMovLastCalibration: '2024-07-14 10:00:00',
        dauMccLastCalibration: '2024-07-15 15:00:00',
        dauMovIp: '192.168.1.102',
        dauMccIp: '192.168.1.103',
        dauMovLastHeartbeat: '2024-07-20 11:30:00',
        dauMccLastHeartbeat: '2024-07-20 11:35:00',
        emailRecipients: 'hhua@cranevs.com'
      },
      {
        title: 'MOV 2KL',
        status: 'offline',
        dauMovName: 'DAU 153A',
        dauMovStatus: 'offline',
        dauMccName: 'DAU 153B',
        dauMccStatus: 'offline',
        dauMovHeartbeatAlerts: false,
        dauMccHeartbeatAlerts: true,
        dauMovNextCalibration: '2024-08-14 10:00:00',
        dauMccNextCalibration: '2024-08-15 15:00:00',
        dauMovLastCalibration: '2024-07-14 10:00:00',
        dauMccLastCalibration: '2024-07-15 15:00:00',
        dauMovIp: '192.168.1.102',
        dauMccIp: '192.168.1.103',
        dauMovLastHeartbeat: '2024-07-20 11:30:00',
        dauMccLastHeartbeat: '2024-07-20 11:35:00',
        emailRecipients: 'hhua@cranevs.com'
      },
      {
        title: 'MOV 5KL',
        status: 'standby',
        dauMovName: 'DAU 623A',
        dauMovStatus: 'standby',
        dauMccName: 'DAU 623B',
        dauMccStatus: 'standby',
        dauMovHeartbeatAlerts: false,
        dauMccHeartbeatAlerts: true,
        dauMovNextCalibration: '2024-08-14 10:00:00',
        dauMccNextCalibration: '2024-08-15 15:00:00',
        dauMovLastCalibration: '2024-07-14 10:00:00',
        dauMccLastCalibration: '2024-07-15 15:00:00',
        dauMovIp: '192.168.1.102',
        dauMccIp: '192.168.1.103',
        dauMovLastHeartbeat: '2024-07-20 11:30:00',
        dauMccLastHeartbeat: '2024-07-20 11:35:00',
        emailRecipients: 'hhua@cranevs.com'
      },
      // Add more valve configurations as needed
    ])

    const filteredValves = computed(() => {
      if (!searchQuery.value) return valves.value
      return valves.value.filter(valve => 
        valve.title.toLowerCase().includes(searchQuery.value.toLowerCase())
      )
    })

    const exportConfig = (valve) => {
      const headers = [
        'Title',
        'Status',
        'DAU@Valve Name',
        'DAU@Remote Name',
        'DAU@Valve Heartbeat Alerts',
        'DAU@Remote Heartbeat Alerts',
        'DAU@Valve Next Calibration',
        'DAU@Remote Next Calibration',
        'DAU@Valve Last Calibration',
        'DAU@Remote Last Calibration',
        'DAU@Valve IP',
        'DAU@Remote IP',
        'DAU@Valve Last Heartbeat',
        'DAU@Remote Last Heartbeat',
        'Email Recipients'
      ]

      const csvContent = [
        headers.join(','),
        [
          valve.title,
          valve.status,
          valve.dauMovName,
          valve.dauMccName,
          valve.dauMovHeartbeatAlerts,
          valve.dauMccHeartbeatAlerts,
          `"${valve.dauMovNextCalibration}"`,
          `"${valve.dauMccNextCalibration}"`,
          `"${valve.dauMovLastCalibration}"`,
          `"${valve.dauMccLastCalibration}"`,
          valve.dauMovIp,
          valve.dauMccIp,
          `"${valve.dauMovLastHeartbeat}"`,
          `"${valve.dauMccLastHeartbeat}"`,
          `"${valve.emailRecipients}"`
        ].join(',')
      ].join('\n')

      const encodedUri = 'data:text/csv;charset=utf-8,' + encodeURIComponent(csvContent)

      const link = document.createElement('a')
      link.setAttribute('href', encodedUri)
      link.setAttribute('download', `${valve.title}_configuration.csv`)
      document.body.appendChild(link)
      link.click()
      document.body.removeChild(link)
    }

    return {
      searchQuery,
      filteredValves,
      exportConfig,
      getDauBorderClass
    }
  }
}
</script>

<style scoped>
.valve-card {
  background-color: white;
  transition: all 0.3s ease;
  border-radius: 8px;
}

.valve-card:hover {
  box-shadow: 0 4px 12px rgba(0,0,0,0.1);
}

.title-border {
  border: 2px solid;
  padding: 8px;
  display: inline-block;
  border-radius: 4px;
}

.status-online {
  border-color: #21BA45;
  background-color: rgba(33, 186, 69, 0.1);
}

.status-standby {
  border-color: #F2C037;
  background-color: rgba(242, 192, 55, 0.1);
}

.status-offline {
  border-color: #C10015;
  background-color: rgba(193, 0, 21, 0.1);
}

.text-h6 {
  color: #1976D2;
  margin: 0;
}

.q-btn {
  transition: background-color 0.3s ease;
}

.q-btn:hover {
  background-color: #1565C0;
}

.text-subtitle1 {
  font-weight: bold;
  margin-bottom: 8px;
}


.dau-border-online {
  border: 2px solid #21BA45 !important; /* Green border */
}

.dau-border-standby {
  border: 2px solid #F2C037 !important; /* Orange border */
}

.dau-border-offline {
  border: 2px solid #C10015 !important;
}
</style>
