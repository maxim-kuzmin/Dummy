<script setup lang="ts">
  import type { AppHeaderData } from '~/utils/app/components/header/app-header.types'
  import { getAppIndexPageService } from '~/utils/app/pages/index/app-index-page.service'

  const _this = (function (appIndexPageService, i18n) {
    const { t } = i18n

    const data = {
      indexPageName: computed(() => t('component.app-header.link.index.text')),
    } as AppHeaderData

    return {
      appIndexPageService,
      data,
    }
  })(getAppIndexPageService(), useI18n())

  _this.data.indexPageUrl = usePageUrl(
    _this.appIndexPageService.createPageUrlOptions(),
  )

  const indexPageName = _this.data.indexPageName
  const indexPageUrl = _this.data.indexPageUrl
</script>

<template>
  <header class="app-header">
    <NuxtLink :to="indexPageUrl">{{ indexPageName }}</NuxtLink>
    <AppLanguage />
  </header>
</template>
