import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useClientResources } from '~/utils/infrastructure/resources/client-resources.composable'
import { useAppIndexPageResources } from './resources/app-index-page-resources.composable'
import { getAppIndexPageService } from './app-index-page.service'

export const useAppIndexPage = (): void => {
  const resourcesModel = useClientResources()
  const appIndexPageResourcesModel = useAppIndexPageResources(resourcesModel)
  const pageStoreModel = usePageStore()

  const appIndexPageService = getAppIndexPageService()

  watchEffect(load)

  function load() {
    pageStoreModel.pageKey.value = appIndexPageService.createPageKey()

    pageStoreModel.pageTitle.value = appIndexPageResourcesModel.getTitle()
  }
}
