import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppIndexPageResources } from './resources/app-index-page-resources.composable'
import { getAppIndexPageService } from './app-index-page.service'

export const useAppIndexPage = (): void => {
  const appIndexPageResources = useAppIndexPageResources()
  const pageStore = usePageStore()

  const appIndexPageService = getAppIndexPageService()

  watchEffect(load)

  function load() {
    pageStore.value = {
      pageKey: appIndexPageService.createPageKey(),
      pageTitle: appIndexPageResources.getTitle(),
    }
  }
}
