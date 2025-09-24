import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppMainComponentStore } from './store/app-main-component-store.composable'
import type { AppMainComponentModel } from './app-main-component.types'

export const useAppMainComponent = (): AppMainComponentModel => {
  const appMainComponentStoreModel = useAppMainComponentStore()
  const pageStoreModel = usePageStore()

  watch(
    pageStoreModel.pageTitle,
    () => {
      appMainComponentStoreModel.load()
    },
    { immediate: true },
  )

  return { ...appMainComponentStoreModel }
}
