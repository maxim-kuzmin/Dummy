<script setup lang="ts">
import { ref } from 'vue'
import WelcomeItem from './WelcomeItem.vue'

const item = ref({ name: '111111' })
</script>

<template>
  <label for="name">name:</label>
  <input id="name" type="text" v-model="item.name" />
  <WelcomeItem v-bind="item"> </WelcomeItem>
</template>
