<script setup lang="ts">
  import { getAppAboutPageService } from '~/utils/app/pages/about/app-about-page.service'
  import type {
    AppAboutPagePayload,
    AppAboutPageResources,
  } from '~/utils/app/pages/about/app-about-page.types'

  const _this = (function (i18n, service) {
    const { t } = i18n

    function createPayload(): AppAboutPagePayload {
      const resources = {
        title: t('page.about.title'),
      } as AppAboutPageResources

      return { resources }
    }

    return {
      load(): void {
        const payload = createPayload()

        service.loadPageData(payload)
      },
      service,
    }
  })(useI18n(), getAppAboutPageService())

  watchEffect(_this.load)
</script>

<template>
  <div>
    <section>
      <h2>About1</h2>
    </section>
    <section>
      <h2>About2</h2>
    </section>
  </div>
</template>
