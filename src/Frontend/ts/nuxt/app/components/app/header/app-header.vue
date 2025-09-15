<script setup lang="ts">
  import { getAppIndexPageService } from '~/utils/pages/index/app-index-page.service'

  const _this = (function (appIndexPageService, i18n) {
    const { t: translate } = i18n

    return {
      appIndexPageService,
      translate,
    }
  })(getAppIndexPageService(), useI18n())

  const indexPageUrl = usePageUrl(_this.appIndexPageService.createPageUrlOptions())

  const indexPageName = computed(() => _this.translate('component.app-header.link.index.text'))
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
