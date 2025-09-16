import { usePageUrl } from '~/utils/shared/page/page.composables'
import { getAppIndexPageService } from '~/utils/app/pages/index/app-index-page.service'
import type { AppHeaderComponentData } from './app-header-component.types'

export const useAppHeaderComponent = () => {
  const appIndexPageService = getAppIndexPageService()

  const { t } = useI18n()

  const data = {
    indexPageName: computed(() => t('component.app-header.link.index.text')),
    indexPageUrl: usePageUrl(appIndexPageService.createPageUrlOptions()),
  } as AppHeaderComponentData

  return { data }
}
