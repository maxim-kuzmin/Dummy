import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { getAppNotFoundPageService } from './app-not-found-page.service'
import { useAppNotFoundPageResources } from './resources/app-not-found-page-resources.composable'

export const useAppNotFoundPage = () => {
  const appNotFoundPageResourcesModel = useAppNotFoundPageResources()
  const pageStoreModel = usePageStore()

  const appNotFoundPageService = getAppNotFoundPageService()

  watchEffect(load)

  function load() {
    pageStoreModel.pageKey.value = appNotFoundPageService.createPageKey()

    pageStoreModel.pageTitle.value = appNotFoundPageResourcesModel.getTitle()
  }
}
