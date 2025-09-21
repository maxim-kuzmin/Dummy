import { usePage } from '~/utils/infrastructure/page/page.composable'
import { useAppAboutPageResources } from './resources/app-about-page-resources.composable'
import { getAppAboutPageService } from './app-about-page.service'

export const useAppAboutPage = (): void => {
  const appAboutPageResourcesModel = useAppAboutPageResources()
  const pageModel = usePage()

  const appAboutPageService = getAppAboutPageService()

  watchEffect(load)

  function load() {
    pageModel.pageKey.value = appAboutPageService.createPageKey()

    pageModel.pageTitle.value = appAboutPageResourcesModel.getTitle()
  }
}
