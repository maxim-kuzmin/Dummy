import type { RouteLocationNormalizedGeneric } from 'vue-router'
import { getAppFakePageApiService } from '~/utils/domain/app/pages/fake/api/app-fake-page-api.service'
import { useAppFakePageStore } from '~/utils/domain/app/pages/fake/store/app-fake-page-store.composable'
import { getLanguageService } from '~/utils/infrastructure/language/language.service'

export default defineNuxtRouteMiddleware(async (to: RouteLocationNormalizedGeneric) => {
  const appFakePageStoreModel = useAppFakePageStore()

  const appFakePageApiService = getAppFakePageApiService()
  const languageService = getLanguageService()

  const dataQuery = appFakePageApiService.getDataQueryFromRouteLocation(to)
  const locale = languageService.getLanguageCodeFromPath(to.path)

  await appFakePageStoreModel.load(dataQuery, { locale })
})
