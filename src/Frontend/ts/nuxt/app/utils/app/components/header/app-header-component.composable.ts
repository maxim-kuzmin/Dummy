import { usePageUrl } from '~/utils/shared/page/url/page-url.composable'
import { getAppIndexPageService } from '~/utils/app/pages/index/app-index-page.service'
import { AppHeaderComponentData } from './app-header-component.types'

export const useAppHeaderComponent = () => {
  const { t } = useI18n()

  const appIndexPageService = getAppIndexPageService()

  const data = new AppHeaderComponentData()

  watchEffect(() => {
    data.indexPageName.value = t('component.app-header.link.index.text')

    data.indexPageUrl.value = usePageUrl(
      appIndexPageService.createPageUrlOptions(),
    )
  })

  return {
    get indexPageName() {
      return data.indexPageName
    },
    get indexPageUrl() {
      return data.indexPageUrl
    },
  }
}
