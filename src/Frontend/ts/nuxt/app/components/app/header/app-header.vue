<script setup lang="ts">
  import { useAppHeaderComponent } from '~/utils/domain-use-cases/app/components/header/app-header-component.composable'

  const { indexPageName, indexPageUrl } = useAppHeaderComponent()
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
