import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useClientResources } from '~/utils/infrastructure/resources/client-resources.composable'
import { getAppNotFoundPageService } from './app-not-found-page.service'
import { useAppNotFoundPageResources } from './resources/app-not-found-page-resources.composable'

export const useAppNotFoundPage = () => {
  const resourcesModel = useClientResources()
  const appNotFoundPageResourcesModel =
    useAppNotFoundPageResources(resourcesModel)
  const pageStoreModel = usePageStore()

  const appNotFoundPageService = getAppNotFoundPageService()

  watchEffect(load)

  function load() {
    pageStoreModel.pageKey.value = appNotFoundPageService.createPageKey()

    pageStoreModel.pageTitle.value = appNotFoundPageResourcesModel.getTitle()
  }
}
