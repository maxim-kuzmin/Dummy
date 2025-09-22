import { getAppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineEventHandler(async (event) => {
  const t = await useTranslation(event)

  const appFakePageService = getAppFakePageService()

  const id = '1'
  const pageNumber = 1

  return {
    pageKey: appFakePageService.createPageKey({ id, pageNumber }),
    pageTitle: t('app.pages.app-fake-page.title', {id: `{${id}}`}),
  } as PageData
})
