import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { getLanguageService } from '~/utils/infrastructure/language/language.service'
import type { PageData } from '~/utils/shared/page/page.types'

export default defineNuxtRouteMiddleware(async (to) => {
  const pageStoreModel = usePageStore()

  const languageService = getLanguageService()

  const locale = languageService.getLanguageCodeFromPath(to.path)

  const res = await useFetch<PageData>(
    '/api/app-about-page-api',
    {
      query: { locale },
    },
  )

  const { pageKey, pageTitle } = res.data.value!

  pageStoreModel.pageKey.value = pageKey
  pageStoreModel.pageTitle.value = pageTitle
})
