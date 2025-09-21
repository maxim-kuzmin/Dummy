import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppAboutPageResources } from './resources/app-about-page-resources.composable'
import { getAppAboutPageService } from './app-about-page.service'

export const useAppAboutPage = (): void => {
  const appAboutPageResources = useAppAboutPageResources()
  const pageStore = usePageStore()

  const appAboutPageService = getAppAboutPageService()

  watchEffect(load)

  function load() {
    pageStore.value = {
      pageKey: appAboutPageService.createPageKey(),
      pageTitle: appAboutPageResources.getTitle(),
    }
  }
}
