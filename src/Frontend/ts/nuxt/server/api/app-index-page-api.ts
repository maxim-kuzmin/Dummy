import { getAppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineEventHandler(async (event) => {
  const t = await useTranslation(event)

  const appIndexPageService = getAppIndexPageService()

  return {
    pageKey: appIndexPageService.createPageKey(),
    pageTitle: t('app.pages.app-index-page.title')
  } as PageData
})
