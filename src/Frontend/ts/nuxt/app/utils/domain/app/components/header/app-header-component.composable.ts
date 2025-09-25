import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppHeaderComponentStore } from './store/app-header-component-store.composable'

export const useAppHeaderComponent = (): void => {
  const appHeaderComponentStoreModel = useAppHeaderComponentStore()
  const languageModel = useLanguage()

  const languageCode = computed(() => languageModel.getCurrentLanguage().code)

  watch(
    languageCode,
    () => {
      appHeaderComponentStoreModel.load()
    },
    { immediate: true },
  )
}
