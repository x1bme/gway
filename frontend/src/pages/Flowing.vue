<template>
  <q-page class="flex flex-center modern-background">
    <div class="flow-container">
      <VueFlow v-model="elements" :fit-view-on-init="true">
        <Background pattern="dots" gap="20" size="1" />
        <template #node-custom="{ data }">
          <div :class="['modern-node', `group-${data.group}`]">
            {{ data.label }}
          </div>
        </template>
      </VueFlow>
    </div>
  </q-page>
</template>

<script>
import { defineComponent, ref } from 'vue'
import { VueFlow } from '@vue-flow/core'
import { Background } from '@vue-flow/background'

export default defineComponent({
  name: 'FlowPage',
  components: {
    VueFlow,
    Background
  },
  setup() {
    const createNode = (id, label, x, y, group = null) => ({
      id,
      type: 'custom',
      position: { x, y },
      data: { label, group }
    })

    const createEdge = (source, target, color, animated = false) => ({
      id: `e${source}-${target}`,
      source,
      target,
      animated,
      style: { stroke: color }
    })

    const elements = ref([
      // Central node
      createNode('C', 'Gemini Server', 500, 400, 'central'),
      
      // Top-left group (both green with flowing edges)
      createNode('TL1', 'DAU156A (@Valve)', 100, 100, 'green'),
      createNode('TL2', 'DAU156B (@Remote)', 250, 100, 'green'),
      
      // Top-right group (orange non-flowing, green flowing)
      createNode('TR1', 'DAU829A (@Valve)', 800, 100, 'orange'),
      createNode('TR2', 'DAU829B (@Remote)', 950, 100, 'green'),
      
      // Bottom-left group (both red, no edges)
      createNode('BL1', 'DAU153A (@Valve)', 100, 500, 'red'),
      createNode('BL2', 'DAU153B (@Remote)', 250, 500, 'red'),
      
      // Bottom-right group (both orange with non-flowing edges)
      createNode('BR1', 'DAU623A (@Valve)', 800, 500, 'orange'),
      createNode('BR2', 'DAU623B (@Remote)', 950, 500, 'orange'),
      
      // Edges
      createEdge('TL1', 'C', '#00FF00', true),  // Green flowing
      createEdge('TL2', 'C', '#00FF00', true),  // Green flowing
      createEdge('TR1', 'C', '#FFA500'),        // Orange non-flowing
      createEdge('TR2', 'C', '#00FF00', true),  // Green flowing
      createEdge('BR1', 'C', '#FFA500'),        // Orange non-flowing
      createEdge('BR2', 'C', '#FFA500'),        // Orange non-flowing
    ])

    return {
      elements
    }
  }
})
</script>

<style>
@import '@vue-flow/core/dist/style.css';
@import '@vue-flow/core/dist/theme-default.css';

.modern-background {
  background: linear-gradient(135deg, #0077be 0%, #87CEEB 100%);
}

.flow-container {
  width: 1000px;
  height: 800px;
  background-color: rgba(255, 255, 255, 0.1);
  border-radius: 15px;
  overflow: hidden;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(5px);
  -webkit-backdrop-filter: blur(5px);
  border: 1px solid rgba(255, 255, 255, 0.3);
}

.modern-node {
  padding: 10px;
  border-radius: 8px;
  font-weight: bold;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
}

.modern-node:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 8px rgba(0, 0, 0, 0.15);
}

.group-central {
  background-color: #ffffff;
  color: #333;
}

.group-green {
  background-color: #00FF00;
  color: black;
}

.group-orange {
  background-color: #FFA500;
  color: black;
}

.group-red {
  background-color: #FF0000;
  color: white;
}

.vue-flow__edge-path {
  stroke-width: 2;
}

.vue-flow__edge.animated path {
  stroke-dasharray: 5;
  animation: dashdraw 0.5s linear infinite;
}

@keyframes dashdraw {
  to {
    stroke-dashoffset: -10;
  }
}
</style>
