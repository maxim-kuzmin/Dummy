import { getPageService } from '~/utils/infrastructure/page/page.service'
import { getAppIndexPageService } from './app-index-page.service'

export const useAppIndexPage = (): void => {
  const { t } = useI18n()

  const appIndexPageService = getAppIndexPageService()
  const pageService = getPageService()

  watchEffect(() => {
    pageService.key.value = appIndexPageService.createPageKey()
    pageService.title.value = t('page.index.title')
  })
}
