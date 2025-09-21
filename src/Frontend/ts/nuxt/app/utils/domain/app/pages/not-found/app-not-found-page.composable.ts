import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { getAppNotFoundPageService } from './app-not-found-page.service'
import { useAppNotFoundPageResources } from './resources/app-not-found-page-resources.composable'

export const useAppNotFoundPage = () => {
  const appNotFoundPageResources = useAppNotFoundPageResources()
  const pageStore = usePageStore()

  const appNotFoundPageService = getAppNotFoundPageService()

  watchEffect(load)

  function load() {
    pageStore.value = {
      pageKey: appNotFoundPageService.createPageKey(),
      pageTitle: appNotFoundPageResources.getTitle(),
    }
  }
}
