import { getAppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service'
import { usePageUrl } from '~/utils/infrastructure/page/url/page-url.composable'

import {
  AppHeaderComponentData,
  type AppHeaderComponentModel,
} from './app-header-component.types'

export const useAppHeaderComponent = (): AppHeaderComponentModel => {
  const { t } = useI18n()

  const appIndexPageService = getAppIndexPageService()

  const data = new AppHeaderComponentData()

  watchEffect(() => {
    data.indexPageName.value = t('component.app-header.link.index.text')

    data.indexPageUrl.value = usePageUrl(
      appIndexPageService.createPageUrlOptions(),
    )
  })

  return { ...data }
}
