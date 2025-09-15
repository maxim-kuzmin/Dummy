<script setup lang="ts">
import { getAppMainService } from '~/utils/app/components/main/app-main.service';

const _this = (function(service) {
  return {
    service
  }
})(
  getAppMainService()
)
const { title } = _this.service;
</script>

<template>
  <main class="app-main">
    <h1>{{ title }}</h1>
    <slot />
  </main>
</template>
