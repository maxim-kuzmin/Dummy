import { getPageService } from '~/utils/shared/page/page.service'
import {
  AppMainComponentData,
  type AppMainComponentService,
} from './app-main-component.types'

export const useAppMainComponentService = () => {
  const pageService = getPageService()

  const data = new AppMainComponentData()

  watchEffect(() => {
    data.title.value = pageService.title.value
  })

  return { ...data } as AppMainComponentService
}
