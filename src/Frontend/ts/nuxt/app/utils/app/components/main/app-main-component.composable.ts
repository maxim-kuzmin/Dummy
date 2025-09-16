import { getPageService } from '~/utils/shared/page/page.service'
import { AppMainComponentData } from './app-main-component.types'

export const useAppMainComponent = () => {
  const pageService = getPageService()

  const data = new AppMainComponentData()

  watchEffect(() => {
    data.title.value = pageService.title.value
  })

  return {
    get title() {
      return data.title
    },
  }
}
