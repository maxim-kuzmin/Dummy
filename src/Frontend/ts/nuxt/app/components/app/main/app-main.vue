<script setup lang="ts">
  import { useAppMainComponentStore } from '~/utils/domain/app/components/main/store/app-main-component-store.composable'
  import { useAppMainComponent } from '~/utils/domain/app/components/main/app-main-component.composable'

  useAppMainComponent()

  const { title } = useAppMainComponentStore()
</script>

<template>
  <main class="app-main">
    <h1>{{ title }}</h1>
    <slot />
  </main>
</template>
