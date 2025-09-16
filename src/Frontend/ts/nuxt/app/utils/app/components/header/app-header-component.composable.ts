import { usePageUrl } from '~/utils/shared/page/url/page-url.composable'
import { getAppIndexPageService } from '~/utils/app/pages/index/app-index-page.service'
import { AppHeaderComponentService } from './app-header-component.service'
import type { AppHeaderComponentPayload } from './app-header-component.types'

export const useAppHeaderComponentService = () => {
  const result = new AppHeaderComponentService()

  const { t } = useI18n()

  const appIndexPageService = getAppIndexPageService()

  watchEffect(() => {
    const payload = {
      indexPageName: t('component.app-header.link.index.text'),
      indexPageUrl: usePageUrl(appIndexPageService.createPageUrlOptions())
    } as AppHeaderComponentPayload

    result.load(payload)
  })

  return result
}
