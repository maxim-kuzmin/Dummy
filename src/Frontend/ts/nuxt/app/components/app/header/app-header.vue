<script setup lang="ts">
  import { useAppHeaderComponentStore } from '~/utils/domain/app/components/header/store/app-header-component-store.composable'
  import { useAppHeaderComponent } from '~/utils/domain/app/components/header/app-header-component.composable'

  useAppHeaderComponent()

  const { indexPageName, indexPageUrl } = useAppHeaderComponentStore()
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
