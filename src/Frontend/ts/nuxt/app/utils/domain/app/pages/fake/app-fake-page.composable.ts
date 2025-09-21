import { getAppFakePageService } from './app-fake-page.service'
import { useAppFakePageResources } from './resources/app-fake-page-resources.composable'
import {
  AppFakePageData,
  AppFakePageParameters,
  type AppFakePageModel,
} from './app-fake-page.types'
import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageResources = useAppFakePageResources()
  const pageStore = usePageStore()
  const route = useRoute()

  const appFakePageService = getAppFakePageService()

  const data = new AppFakePageData()

  watchEffect(load)

  function load() {
    const id = String(route.params[AppFakePageParameters.id.name])

    const pageNumber = Number(
      route.query[AppFakePageParameters.pageNumber.name] ??
        AppFakePageParameters.pageNumber.defaultValue,
    )

    const pageKey = appFakePageService.createPageKey({ id, pageNumber })

    pageStore.value = {
      pageKey,
      pageTitle: appFakePageResources.getTitle(id)
    }

    data.pageKey.value = pageKey
  }

  return {
    ...data,
    click() {
      data.clickCount.value++
    },
  }
}
