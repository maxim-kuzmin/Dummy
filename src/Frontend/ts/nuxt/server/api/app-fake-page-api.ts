import { getAppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service'
import { AppFakePageParameters } from '~/utils/domain/app/pages/fake/app-fake-page.types'
import type { LanguageCode } from '~/utils/shared/language/language.types'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineEventHandler(async (event) => {
  const t = await useTranslation(event)

  const appFakePageService = getAppFakePageService()

  const queryParams = getQuery(event)

  const id = String(
    queryParams[AppFakePageParameters.id.name] ??
      AppFakePageParameters.id.defaultValue,
  )

  const locale = String(
    queryParams[AppFakePageParameters.locale.name] ??
      AppFakePageParameters.locale.defaultValue,
  ) as LanguageCode

  const pageNumber = Number(
    queryParams[AppFakePageParameters.pageNumber.name] ??
      AppFakePageParameters.pageNumber.defaultValue,
  )

  return {
    pageKey: appFakePageService.createPageKey({ id, locale, pageNumber }),
    pageTitle: t('app.pages.app-fake-page.title', { id: `{${id}}` }),
  } as PageData
})
