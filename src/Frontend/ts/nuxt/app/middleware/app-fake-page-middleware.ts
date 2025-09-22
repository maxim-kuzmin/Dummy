import { usePage } from '~/utils/infrastructure/page/page.composable'
import { getLanguageService } from '~/utils/shared/language/language.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineNuxtRouteMiddleware(async (to) => {
  const pageModel = usePage()

  const languageService = getLanguageService()

  const locale = languageService.getLanguageCodeByPath(to.path)

  const res = await useFetch<PageData>(
    '/api/app-fake-page-api',
    {
      query: { locale },
    },
  )

  const { pageKey, pageTitle } = res.data.value!

  pageModel.pageKey.value = pageKey
  pageModel.pageTitle.value = pageTitle
})
