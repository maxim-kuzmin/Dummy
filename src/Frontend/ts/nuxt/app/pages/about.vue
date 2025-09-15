<script setup lang="ts">
  import { getAppAboutPageService } from '~/utils/pages/about/app-about-page.service'

  const _this = (function (i18n, service) {
    const { t: translate } = i18n

    return {
      translate,
      service,
    }
  })(useI18n(), getAppAboutPageService())

  watchEffect(() => {
    const title = _this.translate('page.about.title')

    _this.service.loadPageData({ title })
  })
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
