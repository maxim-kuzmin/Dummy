import { getAppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service'
import { useUrl } from '~/utils/infrastructure/url/url.composable'
import { useAppHeaderComponentResources } from './resources/app-header-component-resources.composable'
import type { AppHeaderComponentModel } from './app-header-component.types'

const storeKey = 'app-header-component'

export const useAppHeaderComponent = (): AppHeaderComponentModel => {
  const appHeaderComponentResourcesModel = useAppHeaderComponentResources()

  const appIndexPageService = getAppIndexPageService()

  const indexPageName = useState(`${storeKey}.indexPageName`, () => '')
  const indexPageUrl = useState(`${storeKey}.indexPageUrl`, () => '')

  watchEffect(load)

  function load(): void {
    indexPageName.value = appHeaderComponentResourcesModel.getTitle()

    indexPageUrl.value = useUrl(appIndexPageService.createPageUrlOptions())
  }

  return { indexPageName, indexPageUrl }
}
