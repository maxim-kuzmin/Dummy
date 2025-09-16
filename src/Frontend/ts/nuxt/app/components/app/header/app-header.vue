<script setup lang="ts">
  import { useAppHeaderComponentService } from '~/utils/app/components/header/app-header-component.composable'

  const { indexPageName, indexPageUrl, click } = useAppHeaderComponentService()

  click()
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
