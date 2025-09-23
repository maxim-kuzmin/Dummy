import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppIndexPageStore } from './store/app-index-page-store.composable'

export const useAppIndexPage = (): void => {
  const appIndexPageStoreModel = useAppIndexPageStore()
  const languageModel = useLanguage()

  watchEffect(async () => {
    const locale = languageModel.getCurrentLanguage().code

    await appIndexPageStoreModel.load({ locale })
  })
}
