import { getPageService } from '~/utils/infrastructure/page/page.service'
import { getAppAboutPageService } from './app-about-page.service'

export const useAppAboutPage = (): void => {
  const { t } = useI18n()

  const appAboutPageService = getAppAboutPageService()
  const pageService = getPageService()

  watchEffect(() => {
    pageService.key.value = appAboutPageService.createPageKey()
    pageService.title.value = t('page.about.title')
  })
}
