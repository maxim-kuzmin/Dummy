<script setup lang="ts">
import { getAppMainComponentService } from '~/utils/app/components/main/app-main-component.service';

const _this = (function(service) {
  return {
    service
  }
})(
  getAppMainComponentService()
)
const { title } = _this.service;
</script>

<template>
  <main class="app-main">
    <h1>{{ title }}</h1>
    <slot />
  </main>
</template>
