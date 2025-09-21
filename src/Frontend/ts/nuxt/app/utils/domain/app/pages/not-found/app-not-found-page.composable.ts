import { usePage } from '~/utils/infrastructure/page/page.composable'
import { getAppNotFoundPageService } from './app-not-found-page.service'
import { useAppNotFoundPageResources } from './resources/app-not-found-page-resources.composable'

export const useAppNotFoundPage = () => {
  const appNotFoundPageResourcesModel = useAppNotFoundPageResources()
  const pageModel = usePage()

  const appNotFoundPageService = getAppNotFoundPageService()

  watchEffect(load)

  function load() {
    pageModel.pageKey.value = appNotFoundPageService.createPageKey()

    pageModel.pageTitle.value = appNotFoundPageResourcesModel.getTitle()
  }
}
