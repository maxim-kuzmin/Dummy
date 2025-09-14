<script setup lang="ts">
  import { getAppIndexPageService } from '~/utils/pages/index/app-index-page.service'

  const _this = (function (localePath, appIndexPageService, i18n) {
    const { t: translate } = i18n

    return {
      localePath,
      appIndexPageService,
      translate,
    }
  })(useLocalePath(), getAppIndexPageService(), useI18n())

  const indexPageName = computed(() => _this.translate('component.app-header.link.index.text'))

  const indexPageUrl = computed(() => _this.localePath({
      name: _this.appIndexPageService.routeName,
      params: _this.appIndexPageService.createRouteParams(),
    }))
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
