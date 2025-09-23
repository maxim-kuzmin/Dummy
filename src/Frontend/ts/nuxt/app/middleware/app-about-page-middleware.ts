import { useAppAboutPageStore } from '~/utils/domain/app/pages/about/store/app-about-page-store.composable'
import { getLanguageService } from '~/utils/infrastructure/language/language.service'

export default defineNuxtRouteMiddleware(async (to) => {
  const appAboutPageStoreModel = useAppAboutPageStore()

  const languageService = getLanguageService()

  const locale = languageService.getLanguageCodeFromPath(to.path)

  await appAboutPageStoreModel.load({ locale })
})
