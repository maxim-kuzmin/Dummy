import { getPageService } from '~/utils/shared/page/page.service'
import {
  AppMainComponentData,
  type AppMainComponentModel,
} from './app-main-component.types'

export const useAppMainComponent = (): AppMainComponentModel => {
  const pageService = getPageService()

  const data = new AppMainComponentData()

  watchEffect(() => {
    data.title.value = pageService.title.value
  })

  return { ...data }
}
