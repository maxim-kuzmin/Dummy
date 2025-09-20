import { getPageStoreService } from '~/utils/infrastructure/page/store/page-store.service'
import {
  AppMainComponentData,
  type AppMainComponentModel,
} from './app-main-component.types'

export const useAppMainComponent = (): AppMainComponentModel => {
  const pageStoreService = getPageStoreService()

  const data = new AppMainComponentData()

  watchEffect(() => {
    data.title.value = pageStoreService.pageTitle
  })

  return { ...data }
}
