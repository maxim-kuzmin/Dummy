import { usePage } from '~/utils/infrastructure/page/page.composable'
import { getAppFakePageService } from './app-fake-page.service'
import { useAppFakePageResources } from './resources/app-fake-page-resources.composable'
import {
  AppFakePageParameters,
  type AppFakePageModel,
} from './app-fake-page.types'
import { useAppFakePageStore } from './store/app-fake-page-store.composable'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageResourcesModel = useAppFakePageResources()
  const appFakePageStoreModel = useAppFakePageStore()
  const pageModel = usePage()

  const route = useRoute()

  const appFakePageService = getAppFakePageService()

  watchEffect(load)

  function load() {
    const id = String(route.params[AppFakePageParameters.id.name])

    const pageNumber = Number(
      route.query[AppFakePageParameters.pageNumber.name] ??
        AppFakePageParameters.pageNumber.defaultValue,
    )

    pageModel.pageKey.value = appFakePageService.createPageKey({
      id,
      pageNumber,
    })

    pageModel.pageTitle.value = appFakePageResourcesModel.getTitle(id)

    appFakePageStoreModel.pageKey.value = pageModel.pageKey.value
  }

  return { ...appFakePageStoreModel }
}
