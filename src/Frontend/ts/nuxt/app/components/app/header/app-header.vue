<script setup lang="ts">
  import { useAppHeaderComponent } from '~/utils/app/components/header/app-header-component.composable'

  const _this = useAppHeaderComponent()

  const indexPageName = _this.data.indexPageName
  const indexPageUrl = _this.data.indexPageUrl
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
