import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppMainComponentStore } from './store/app-main-component-store.composable'

export const useAppMainComponent = (): void => {
  const appMainComponentStoreModel = useAppMainComponentStore()
  const pageStoreModel = usePageStore()

  watch(
    pageStoreModel.pageTitle,
    () => {
      appMainComponentStoreModel.load()
    },
    { immediate: true },
  )
}
