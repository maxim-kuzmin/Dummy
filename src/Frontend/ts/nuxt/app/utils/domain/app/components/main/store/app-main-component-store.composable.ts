import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import type { AppMainComponentStoreModel } from './app-main-component-store.types'

const storeKey = 'app-main-component'

export const useAppMainComponentStore = (): AppMainComponentStoreModel => {
  const pageStoreModel = usePageStore()

  const title = useState(`${storeKey}.title`, () => '')

  return {
    title: readonly(title),
    load(): void {
      title.value = pageStoreModel.pageTitle.value
    },
  }
}
