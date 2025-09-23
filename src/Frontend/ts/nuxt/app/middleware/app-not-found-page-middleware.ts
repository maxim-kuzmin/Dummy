import { useAppNotFoundPageStore } from '~/utils/domain/app/pages/not-found/store/app-not-found-page-store.composable'
import { getLanguageService } from '~/utils/infrastructure/language/language.service'

export default defineNuxtRouteMiddleware(async (to) => {
  const appNotFoundPageStoreModel = useAppNotFoundPageStore()

  const languageService = getLanguageService()

  const locale = languageService.getLanguageCodeFromPath(to.path)

  await appNotFoundPageStoreModel.load({ locale })
})
