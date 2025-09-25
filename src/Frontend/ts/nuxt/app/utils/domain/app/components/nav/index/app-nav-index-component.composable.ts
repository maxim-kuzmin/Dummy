import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppNavIndexComponentStore } from './store/app-nav-index-component-store.composable'

export const useAppNavIndexComponent = (): void => {
  const appNavIndexComponentStoreModel = useAppNavIndexComponentStore()
  const pageStoreModel = usePageStore()

  watch(
    pageStoreModel.pageKey,
    () => {
      appNavIndexComponentStoreModel.load()
    },
    { immediate: true },
  )
}
