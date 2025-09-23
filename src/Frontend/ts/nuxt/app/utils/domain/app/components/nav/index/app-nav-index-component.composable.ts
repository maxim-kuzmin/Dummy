import { useAppNavIndexComponentStore } from './store/app-nav-index-component-store.composable'
import type { AppNavIndexComponentModel } from './app-nav-index-component.types'

export const useAppNavIndexComponent = (): AppNavIndexComponentModel => {
  const appNavIndexComponentStoreModel = useAppNavIndexComponentStore()

  watchEffect(() => {
    appNavIndexComponentStoreModel.load()
  })

  return { ...appNavIndexComponentStoreModel }
}
