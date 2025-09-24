import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppHeaderComponentStore } from './store/app-header-component-store.composable'
import type { AppHeaderComponentModel } from './app-header-component.types'

export const useAppHeaderComponent = (): AppHeaderComponentModel => {
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

  return { ...appHeaderComponentStoreModel }
}
