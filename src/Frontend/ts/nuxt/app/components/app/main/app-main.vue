<script setup lang="ts">
import { useAppMainComponent } from '~/utils/app/components/main/app-main-component.composable';

const { title } = useAppMainComponent();
</script>

<template>
  <main class="app-main">
    <h1>{{ title }}</h1>
    <slot />
  </main>
</template>
