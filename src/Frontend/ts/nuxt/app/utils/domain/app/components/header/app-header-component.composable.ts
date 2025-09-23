import { useAppHeaderComponentStore } from './store/app-header-component-store.composable'
import type { AppHeaderComponentModel } from './app-header-component.types'

export const useAppHeaderComponent = (): AppHeaderComponentModel => {
  const appHeaderComponentStoreModel = useAppHeaderComponentStore()

  watchEffect(() => {
    appHeaderComponentStoreModel.load()
  })

  return { ...appHeaderComponentStoreModel }
}
