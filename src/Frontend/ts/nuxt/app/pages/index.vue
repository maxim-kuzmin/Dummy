<script setup lang="ts">
  import { getAppIndexPageService } from '~/utils/app/pages/index/app-index-page.service'
  import type {
    AppIndexPagePayload,
    AppIndexPageResources,
  } from '~/utils/app/pages/index/app-index-page.types'

  const _this = (function (i18n, service) {
    const { t } = i18n

    function createPayload(): AppIndexPagePayload {
      const resources = {
        title: t('page.index.title'),
      } as AppIndexPageResources

      return { resources }
    }

    return {
      load(): void {
        const payload = createPayload()

        service.loadPageData(payload)
      },
      service,
    }
  })(useI18n(), getAppIndexPageService())

  watchEffect(_this.load)
</script>

<template>
  <div>
    <section>
      <h2>Index1</h2>
    </section>
    <section>
      <h2>Index2</h2>
    </section>
  </div>
</template>
