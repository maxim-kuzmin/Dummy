import { getPageService } from '~/utils/infrastructure/page/page.service'
import { useAppIndexPageResources } from './resources/app-index-page-resources.composable'
import { getAppIndexPageService } from './app-index-page.service'

export const useAppIndexPage = (): void => {
  const appIndexPageResourcesModel = useAppIndexPageResources()

  const appIndexPageService = getAppIndexPageService()
  const pageService = getPageService()

  watchEffect(() => {
    pageService.key.value = appIndexPageService.createPageKey()
    pageService.title.value = appIndexPageResourcesModel.getTitle()
  })
}
