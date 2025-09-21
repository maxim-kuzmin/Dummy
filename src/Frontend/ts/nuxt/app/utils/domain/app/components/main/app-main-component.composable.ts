import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import type { AppMainComponentModel } from './app-main-component.types'

const storeKey = 'app-main-component'

export const useAppMainComponent = (): AppMainComponentModel => {
  const pageStoreModel = usePageStore()

  const title = useState(`${storeKey}.title`, () => '')

  watchEffect(load)

  function load(): void {
    title.value = pageStoreModel.pageTitle.value
  }

  return { title }
}
