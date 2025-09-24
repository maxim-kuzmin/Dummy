import { getAppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service'
import { usePageUrl } from '~/utils/infrastructure/page/url/page-url.composable'
import { useClientResources } from '~/utils/infrastructure/resources/client-resources.composable'
import { useAppHeaderComponentResources } from '../resources/app-header-component-resources.composable'
import type { AppHeaderComponentStoreModel } from './app-header-component-store.types'

const storeKey = 'app-header-component'

export const useAppHeaderComponentStore = (): AppHeaderComponentStoreModel => {
  const resourcesModel = useClientResources()

  const appHeaderComponentResourcesModel =
    useAppHeaderComponentResources(resourcesModel)

  const appIndexPageService = getAppIndexPageService()

  const indexPageName = useState(`${storeKey}.indexPageName`, () => '')
  const indexPageUrl = useState(`${storeKey}.indexPageUrl`, () => '')

  return {
    indexPageName: readonly(indexPageName),
    indexPageUrl: readonly(indexPageUrl),
    load(): void {
      indexPageName.value = appHeaderComponentResourcesModel.getTitle()

      indexPageUrl.value = usePageUrl(
        appIndexPageService.createPageUrlOptions(),
      )
    },
  }
}
