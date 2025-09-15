<script setup lang="ts">
  import { getAppIndexPageService } from '~/utils/pages/index/app-index-page.service'

  const _this = (function (i18n, service) {
    const { t: translate } = i18n

    return {
      translate,
      service,
    }
  })(useI18n(), getAppIndexPageService())

  watchEffect(() => {
    const title = _this.translate('page.index.title')

    _this.service.loadPageData({ title })
  })
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
