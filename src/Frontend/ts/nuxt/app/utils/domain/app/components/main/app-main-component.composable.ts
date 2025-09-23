import { useAppMainComponentStore } from './store/app-main-component-store.composable'
import type { AppMainComponentModel } from './app-main-component.types'

export const useAppMainComponent = (): AppMainComponentModel => {
  const appMainComponentStoreModel = useAppMainComponentStore()

  watchEffect(() => {
    appMainComponentStoreModel.load()
  })

  return { ...appMainComponentStoreModel }
}
