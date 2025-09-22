import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { getLanguageService } from '~/utils/shared/language/language.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineNuxtRouteMiddleware(async (to) => {
  const pageStoreModel = usePageStore()

  const languageService = getLanguageService()

  const locale = languageService.getLanguageCodeByPath(to.path)

  const res = await useFetch<PageData>(
    '/api/app-index-page-api',
    {
      query: { locale },
    },
  )

  const { pageKey, pageTitle } = res.data.value!

  pageStoreModel.pageKey.value = pageKey
  pageStoreModel.pageTitle.value = pageTitle
})
