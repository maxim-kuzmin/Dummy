import { useAppIndexPageStore } from '~/utils/domain/app/pages/index/store/app-index-page-store.composable'
import { getLanguageService } from '~/utils/infrastructure/language/language.service'

export default defineNuxtRouteMiddleware(async (to) => {
  const appIndexPageStoreModel = useAppIndexPageStore()

  const languageService = getLanguageService()

  const locale = languageService.getLanguageCodeFromPath(to.path)

  await appIndexPageStoreModel.load({ locale })
})
