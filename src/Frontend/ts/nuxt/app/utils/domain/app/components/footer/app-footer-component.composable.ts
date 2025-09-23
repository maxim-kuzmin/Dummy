import { useAppFooterComponentStore } from './store/app-footer-component-store.composable'
import type { AppFooterComponentModel } from './app-footer-component.types'

export const useAppFooterComponent = (): AppFooterComponentModel => {
  const appFooterComponentStoreModel = useAppFooterComponentStore()

  watchEffect(() => {
    appFooterComponentStoreModel.load()
  })

  return { ...appFooterComponentStoreModel }
}
