<script setup lang="ts">
  import { getAppFakePageService } from '~/utils/pages/fake/app-fake-page.service'
  import type { PageParameters } from '~/utils/pages/fake/app-fake-page.types'

  const _this = (function (i18n, service, route) {
    const { t: translate } = i18n

    const parameters = {
      id: computed(() => route.params.id),
    } as PageParameters

    return {
      translate,
      service,
      parameters,
    }
  })(useI18n(), getAppFakePageService(), useRoute())

  const key = _this.service.pageData.key

  watchEffect(() => {
    _this.service.loadPageData(_this.parameters.id.value, _this.translate)
  })
</script>

<template>
  <div>
    {{ key }}
  </div>
</template>
