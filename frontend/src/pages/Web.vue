<template>
  <q-page padding>
    <div class="row q-col-gutter-md">
      <div class="col-12">
        <h4 class="q-mt-none q-mb-md">Web Interface Configuration</h4>
      </div>
      
      <!-- Network Settings -->
      <div class="col-12 col-md-6">
        <q-card>
          <q-card-section>
            <div class="text-h6">Network Settings</div>
          </q-card-section>
          <q-card-section>
            <q-input v-model="config.ipAddress" label="IP Address" filled />
            <q-input v-model="config.port" label="Port" type="number" filled />
            <q-input v-model="config.dnsServer" label="DNS Server" filled />
            <q-select v-model="config.networkInterface" :options="networkInterfaces" label="Network Interface" filled />
          </q-card-section>
        </q-card>
      </div>

      <!-- Security Settings -->
      <div class="col-12 col-md-6">
        <q-card>
          <q-card-section>
            <div class="text-h6">Security Settings</div>
          </q-card-section>
          <q-card-section>
            <q-toggle v-model="config.sslEnabled" label="Enable SSL/TLS" />
            <q-input v-model="config.sslCertPath" label="SSL Certificate Path" filled :disable="!config.sslEnabled" />
            <q-input v-model="config.sslKeyPath" label="SSL Key Path" filled :disable="!config.sslEnabled" />
            <q-select v-model="config.encryptionScheme" :options="encryptionSchemes" label="Data Encryption Scheme" filled />
          </q-card-section>
        </q-card>
      </div>

      <!-- Logging Settings -->
      <div class="col-12 col-md-6">
        <q-card>
          <q-card-section>
            <div class="text-h6">Logging Settings</div>
          </q-card-section>
          <q-card-section>
            <q-input v-model="config.logPath" label="Log File Path" filled />
            <q-select v-model="config.logLevel" :options="logLevels" label="Log Level" filled />
            <q-toggle v-model="config.enableAccessLog" label="Enable Access Log" />
            <q-input v-model="config.accessLogPath" label="Access Log Path" filled :disable="!config.enableAccessLog" />
          </q-card-section>
        </q-card>
      </div>

      <!-- Performance Settings -->
      <div class="col-12 col-md-6">
        <q-card>
          <q-card-section>
            <div class="text-h6">Performance Settings</div>
          </q-card-section>
          <q-card-section>
            <q-input v-model="config.maxConnections" label="Max Simultaneous Connections" type="number" filled />
            <q-input v-model="config.connectionTimeout" label="Connection Timeout (seconds)" type="number" filled />
            <q-toggle v-model="config.enableCompression" label="Enable Compression" />
            <q-select v-model="config.compressionLevel" :options="compressionLevels" label="Compression Level" filled :disable="!config.enableCompression" />
          </q-card-section>
        </q-card>
      </div>


      <!-- Save Button -->
      <div class="col-12 q-mt-md">
        <q-btn color="primary" label="Save Configuration" @click="saveConfig" />
      </div>
    </div>
  </q-page>
</template>

<script>
import { ref } from 'vue'

export default {
  setup() {
    const config = ref({
      ipAddress: '192.168.1.100',
      port: 8080,
      dnsServer: '8.8.8.8',
      networkInterface: 'eth0',
      sslEnabled: true,
      sslCertPath: '/etc/ssl/certs/server.crt',
      sslKeyPath: '/etc/ssl/private/server.key',
      encryptionScheme: 'AES-256-GCM',
      logPath: '/var/log/server.log',
      logLevel: 'INFO',
      enableAccessLog: true,
      accessLogPath: '/var/log/access.log',
      maxConnections: 1000,
      connectionTimeout: 30,
      enableCompression: true,
      compressionLevel: 6,
      hardwarePollingInterval: 1000,
      enableHardwareLogging: true,
      hardwareLogPath: '/var/log/hardware.log'
    })

    const networkInterfaces = ['eth0', 'eth1', 'wlan0', 'wlan1']
    const encryptionSchemes = ['AES-256-GCM', 'ChaCha20-Poly1305', 'TLS_AES_128_GCM_SHA256']
    const logLevels = ['DEBUG', 'INFO', 'WARNING', 'ERROR', 'CRITICAL']
    const compressionLevels = [1, 2, 3, 4, 5, 6, 7, 8, 9]

    const saveConfig = () => {
      // Implement save logic here
      console.log('Saving configuration:', config.value)
      // You might want to send this to an API endpoint
    }

    return {
      config,
      networkInterfaces,
      encryptionSchemes,
      logLevels,
      compressionLevels,
      saveConfig
    }
  }
}
</script>

<style scoped>
.q-card {
  height: 100%;
}
</style>
