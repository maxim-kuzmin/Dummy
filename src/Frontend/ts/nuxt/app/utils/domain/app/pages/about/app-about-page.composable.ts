import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppAboutPageStore } from './store/app-about-page-store.composable'

export const useAppAboutPage = (): void => {
  const appAboutPageStoreModel = useAppAboutPageStore()
  const languageModel = useLanguage()

  watchEffect(async () => {
    const locale = languageModel.getCurrentLanguage().code

    await appAboutPageStoreModel.load({ locale })
  })
}
