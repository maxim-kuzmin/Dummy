import { getAppAboutPageService } from '~/utils/app/pages/about/app-about-page.service'
import { getAppFakePageService } from '~/utils/app/pages/fake/app-fake-page.service'
import { usePageUrl } from '~/utils/shared/page/url/page-url.composable'
import { AppNavComponentService } from './app-nav-component.service'
import type { AppNavComponentPayload } from './app-nav-component.types'

export const useAppNavComponentService = () => {
  const result = new AppNavComponentService()

  const appIndexPageService = getAppAboutPageService()
  const appFakePageService = getAppFakePageService()

  watchEffect(() => {
    const payload = {
      aboutPageUrl: usePageUrl(appIndexPageService.createPageUrlOptions()),
      fakePageUrl1: usePageUrl(
        appFakePageService.createPageUrlOptions({
          id: '1',
          pageNumber: 1,
        }),
      ),
      fakePageUrl1pn2: usePageUrl(
        appFakePageService.createPageUrlOptions({
          id: '1',
          pageNumber: 2,
        }),
      ),
      fakePageUrl2: usePageUrl(
        appFakePageService.createPageUrlOptions({
          id: '2',
          pageNumber: 1,
        }),
      ),
    } as AppNavComponentPayload

    result.load(payload)
  })

  return result
}
