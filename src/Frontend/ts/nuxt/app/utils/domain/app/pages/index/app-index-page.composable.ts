import { usePage } from '~/utils/infrastructure/page/page.composable'
import { useAppIndexPageResources } from './resources/app-index-page-resources.composable'
import { getAppIndexPageService } from './app-index-page.service'

export const useAppIndexPage = (): void => {
  const appIndexPageResourcesModel = useAppIndexPageResources()
  const pageModel = usePage()

  const appIndexPageService = getAppIndexPageService()

  watchEffect(load)

  function load() {
    pageModel.pageKey.value = appIndexPageService.createPageKey()

    pageModel.pageTitle.value = appIndexPageResourcesModel.getTitle()

    console.log('MAKC:useAppIndexPage:load', pageModel.pageTitle.value)
  }
}
