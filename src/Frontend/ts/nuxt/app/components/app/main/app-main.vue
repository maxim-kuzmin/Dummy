<script setup lang="ts">
import { useAppMainComponentService } from '~/utils/app/components/main/app-main-component.composable';

const { title } = useAppMainComponentService();
</script>

<template>
  <main class="app-main">
    <h1>{{ title }}</h1>
    <slot />
  </main>
</template>
