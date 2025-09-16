import { getAppAboutPageService } from '~/utils/app/pages/about/app-about-page.service'
import { getAppFakePageService } from '~/utils/app/pages/fake/app-fake-page.service'
import { usePageUrl } from '~/utils/shared/page/url/page-url.composable'
import { AppNavComponentData } from './app-nav-component.types'

export const useAppNavComponent = () => {
  const appIndexPageService = getAppAboutPageService()
  const appFakePageService = getAppFakePageService()

  const data = new AppNavComponentData()

  watchEffect(() => {
    data.aboutPageUrl.value = usePageUrl(
      appIndexPageService.createPageUrlOptions(),
    )

    data.fakePageUrl1.value = usePageUrl(
      appFakePageService.createPageUrlOptions({
        id: '1',
        pageNumber: 1,
      }),
    )

    data.fakePageUrl1pn2.value = usePageUrl(
      appFakePageService.createPageUrlOptions({
        id: '1',
        pageNumber: 2,
      }),
    )

    data.fakePageUrl2.value = usePageUrl(
      appFakePageService.createPageUrlOptions({
        id: '2',
        pageNumber: 1,
      }),
    )
  })

  return { data }
}
