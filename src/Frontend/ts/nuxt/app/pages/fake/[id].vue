<script setup lang="ts">
  import { getAppFakePageService } from '~/utils/pages/fake/app-fake-page.service'
  import type { AppFakePageParameters } from '~/utils/pages/fake/app-fake-page.types'

  const _this = (function (i18n, service, route) {
    const { t: translate } = i18n

    const parameters = {
      id: computed(() => route.params.id),
    } as AppFakePageParameters

    return {
      translate,
      service,
      parameters,
    }
  })(useI18n(), getAppFakePageService(), useRoute())

  const key = _this.service.pageData.key

  watchEffect(() => {
    const id = _this.parameters.id.value
    const title = _this.translate('page.fake.title', [id])

    _this.service.loadPageData({ id, title })
  })
</script>

<template>
  <div>
    {{ key }}
  </div>
</template>
