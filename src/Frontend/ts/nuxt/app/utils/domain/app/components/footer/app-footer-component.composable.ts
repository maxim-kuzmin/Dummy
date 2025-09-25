import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppFooterComponentStore } from './store/app-footer-component-store.composable'

export const useAppFooterComponent = (): void => {
  const appFooterComponentStoreModel = useAppFooterComponentStore()

  const languageModel = useLanguage()

  const languageCode = computed(() => languageModel.getCurrentLanguage().code)

  watch(
    languageCode,
    () => {
      appFooterComponentStoreModel.load()
    },
    { immediate: true },
  )
}
