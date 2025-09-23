import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppNotFoundPageStore } from './store/app-not-found-page-store.composable'

export const useAppNotFoundPage = (): void => {
  const appNotFoundPageStoreModel = useAppNotFoundPageStore()
  const languageModel = useLanguage()

  watchEffect(async () => {
    const locale = languageModel.getCurrentLanguage().code

    await appNotFoundPageStoreModel.load({ locale })
  })
}
