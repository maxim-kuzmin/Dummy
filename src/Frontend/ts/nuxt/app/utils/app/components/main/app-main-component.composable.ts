import { getPageService } from '~/utils/shared/page/page.service'
import { AppMainComponentService } from './app-main-component.service'
import type { AppMainComponentPayload } from './app-main-component.types'

export const useAppMainComponentService = () => {
  const result = new AppMainComponentService()

  const pageService = getPageService()

  watchEffect(() => {
    const payload = {
      title: pageService.title.value
    } as AppMainComponentPayload

    result.load(payload)
  })

  return result
}
