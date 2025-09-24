import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppFooterComponentStore } from './store/app-footer-component-store.composable'
import type { AppFooterComponentModel } from './app-footer-component.types'

export const useAppFooterComponent = (): AppFooterComponentModel => {
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

  return { ...appFooterComponentStoreModel }
}
