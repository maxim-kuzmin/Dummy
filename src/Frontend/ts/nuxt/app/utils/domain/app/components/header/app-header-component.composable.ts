import { getAppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service'
import { usePageUrl } from '~/utils/infrastructure/page/url/page-url.composable'
import { useAppHeaderComponentResources } from './resources/app-header-component-resources.composable'
import {
  AppHeaderComponentData,
  type AppHeaderComponentModel,
} from './app-header-component.types'

export const useAppHeaderComponent = (): AppHeaderComponentModel => {
  const appHeaderComponentResources = useAppHeaderComponentResources()

  const appIndexPageService = getAppIndexPageService()

  const data = new AppHeaderComponentData()

  watchEffect(() => {
    data.indexPageName.value = appHeaderComponentResources.getTitle()

    data.indexPageUrl.value = usePageUrl(
      appIndexPageService.createPageUrlOptions(),
    )
  })

  return { ...data }
}
