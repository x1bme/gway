<template>
    <q-page padding class="flex flex-center">
        <q-card class="login-card">
            <q-card-section class="text-center">
                <div class="text-h4 q-mb-md">API Test</div>
                <q-btn color="primary" label="TEST API" size="lg" @click="" class="full-width"/>
            </q-card-section>
        </q-card>
    </q-page>
</template>

<script>
import { defineComponent, ref, computed, onMounted } from 'vue'; 
import { useValveStore } from 'src/stores';
import { useQuasar } from 'quasar';

export default defineComponent({
    name: 'TEST',
    setup() {
        const valveStore = useValveStore();
        const q = useQuasar();
        const valves = computed(() => valveStore.valves);
        const loading = computed(() => valveStore.loading);
        onMounted(async () => {
            try {
                await valveStore.fetchValves();
            } catch (error) {
                q.notify({
                    color: 'negative',
                    message: `Failed to load valves`,
                    icon: 'error'
                });
                console.error(`Failed to load valves: ${error}`);
            }
        });
        return {
            valves,
            loading
        }
    }
});
</script>

<style scoped>
    .login-card {
        max-width: 400px;
        width: 100%;
    }
</style>