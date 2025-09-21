import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import {
  AppMainComponentData,
  type AppMainComponentModel,
} from './app-main-component.types'

export const useAppMainComponent = (): AppMainComponentModel => {
  const pageStore = usePageStore()

  const data = new AppMainComponentData()

  watchEffect(load)

  function load() {
    data.title.value = pageStore.value.pageTitle
  }

  return { ...data, refresh: load }
}
