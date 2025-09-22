import { getAppNotFoundPageService } from '~/utils/domain/app/pages/not-found/app-not-found-page.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineEventHandler(async (event) => {
  const t = await useTranslation(event)

  const appNotFoundPageService = getAppNotFoundPageService()

  return {
    pageKey: appNotFoundPageService.createPageKey(),
    pageTitle: t('app.pages.app-not-found-page.title')
  } as PageData
})
