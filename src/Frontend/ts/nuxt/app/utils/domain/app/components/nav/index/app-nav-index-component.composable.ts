import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppNavIndexComponentStore } from './store/app-nav-index-component-store.composable'
import type { AppNavIndexComponentModel } from './app-nav-index-component.types'

export const useAppNavIndexComponent = (): AppNavIndexComponentModel => {
  const appNavIndexComponentStoreModel = useAppNavIndexComponentStore()
  const pageStoreModel = usePageStore()

  watch(
    pageStoreModel.pageKey,
    () => {
      appNavIndexComponentStoreModel.load()
    },
    { immediate: true },
  )

  return { ...appNavIndexComponentStoreModel }
}
