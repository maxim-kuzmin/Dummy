import { getPageService } from '~/utils/infrastructure/page/page.service'
import { useAppAboutPageResources } from './resources/app-about-page-resources.composable'
import { getAppAboutPageService } from './app-about-page.service'

export const useAppAboutPage = (): void => {
  const appAboutPageResourcesModel = useAppAboutPageResources()

  const appAboutPageService = getAppAboutPageService()
  const pageService = getPageService()

  watchEffect(() => {
    pageService.key.value = appAboutPageService.createPageKey()
    pageService.title.value = appAboutPageResourcesModel.getTitle()
  })
}
