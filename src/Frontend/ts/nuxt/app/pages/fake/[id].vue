<script setup lang="ts">
  import type { AppAboutPageResources } from '~/utils/app/pages/about/app-about-page.types'
  import { getAppFakePageService } from '~/utils/app/pages/fake/app-fake-page.service'
  import type {
    AppFakePageDataQuery,
    AppFakePageParameters,
    AppFakePagePayload,
  } from '~/utils/app/pages/fake/app-fake-page.types'

  const _this = (function (i18n, service, route) {
    const { t } = i18n

    const parameters = {
      id: computed(() => route.params[service.parameterNames.id]),
      pageNumber: computed(() =>
        Number(route.query[service.parameterNames.pageNumber] ?? 1),
      ),
    } as AppFakePageParameters

    function createPayload(): AppFakePagePayload {
      const dataQuery = {
        id: parameters.id.value,
        pageNumber: parameters.pageNumber.value,
      } as AppFakePageDataQuery

      const resources = {
        title: t('page.fake.title', [dataQuery.id]),
      } as AppAboutPageResources

      return { dataQuery, resources }
    }

    return {
      data: service.data,
      load(): void {
        const payload = createPayload()

        service.load(payload)
      },
    }
  })(useI18n(), getAppFakePageService(), useRoute())

  watchEffect(_this.load)

  const key = _this.data.key
</script>

<template>
  <div>
    {{ key }}
  </div>
</template>
