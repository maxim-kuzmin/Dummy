import { getAppAboutPageService } from '~/utils/domain/app/pages/about/app-about-page.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineEventHandler(async (event) => {
  const t = await useTranslation(event)

  const appAboutPageService = getAppAboutPageService()

  return {
    pageKey: appAboutPageService.createPageKey(),
    pageTitle: t('app.pages.app-about-page.title')
  } as PageData
})
