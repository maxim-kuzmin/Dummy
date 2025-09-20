import { getAppAboutPageService } from '~/utils/domain/app/pages/about/app-about-page.service'
import { getAppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service'
import { usePageUrl } from '~/utils/infrastructure/page/url/page-url.composable'
import {
  AppNavComponentData,
  type AppNavComponentItem,
  type AppNavComponentModel,
} from './app-nav-component.types'
import { getPageStoreService } from '~/utils/infrastructure/page/store/page-store.service'
import type { AppFakePageDataQuery } from '../../pages/fake/app-fake-page.types'
import { useAppAboutPageResources } from '../../pages/about/resources/app-about-page-resources.composable'

export const useAppNavComponent = (): AppNavComponentModel => {
  const appAboutPageResourcesModel = useAppAboutPageResources()

  const appAboutPageService = getAppAboutPageService()
  const appFakePageService = getAppFakePageService()
  const pageStoreService = getPageStoreService()

  const data = new AppNavComponentData()

  watchEffect(() => {
    data.aboutPageUrl.value = usePageUrl(
      appAboutPageService.createPageUrlOptions(),
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

    data.items.value = createFakeItems()
  })

  function createFakeItems(): AppNavComponentItem[] {
    return [
      createItemForAboutPage(),
      createItemForFakePageByDataQuery({ id: '1', pageNumber: 1 }),
      createItemForFakePageByDataQuery({ id: '1', pageNumber: 2 }),
      createItemForFakePageByDataQuery({ id: '2', pageNumber: 1 }),
      createItemForFakePage('11111', [
        createItemForFakePage('11111-1'),
        createItemForFakePage('11111-2'),
        createItemForFakePage('11111-3', [
          createItemForFakePage('11111-3-1'),
          createItemForFakePage('11111-3-2'),
          createItemForFakePage('11111-3-3', [
            createItemForFakePage('11111-3-3-1'),
            createItemForFakePage('11111-3-3-2'),
            createItemForFakePage('11111-3-3-3'),
            createItemForFakePage('11111-3-3-4'),
            createItemForFakePage('11111-3-3-5'),
          ]),
          createItemForFakePage('11111-3-4'),
          createItemForFakePage('11111-3-5'),
        ]),
        createItemForFakePage('11111-4'),
        createItemForFakePage('11111-5'),
      ]),
      createItemForFakePage('22222'),
      createItemForFakePage('33333'),
      createItemForFakePage('44444'),
      createItemForFakePage('55555'),
    ]
  }

  function createItemForAboutPage(): AppNavComponentItem {
    const text = appAboutPageResourcesModel.getTitle()

    const key = appAboutPageService.createPageKey()

    const url = usePageUrl(appAboutPageService.createPageUrlOptions())

    return createItem(key, url, text)
  }

  function createItemForFakePage(
    text: string,
    children: AppNavComponentItem[] = [],
  ): AppNavComponentItem {
    const dataQuery = { id: text, pageNumber: 1 } as AppFakePageDataQuery

    const key = appFakePageService.createPageKey(dataQuery)

    const urlTree = usePageUrl(
      appFakePageService.createPageUrlOptions(dataQuery),
    )

    return createItem(key, urlTree, text, children)
  }

  function createItemForFakePageByDataQuery(
    dataQuery: AppFakePageDataQuery,
    children: AppNavComponentItem[] = [],
  ): AppNavComponentItem {
    const key = appFakePageService.createPageKey(dataQuery)
    const url = usePageUrl(appFakePageService.createPageUrlOptions(dataQuery))

    return createItem(key, url, key, children)
  }

  function createItem(
    key: string,
    url: string,
    text: string,
    children: AppNavComponentItem[] = [],
  ): AppNavComponentItem {
    const selected = pageStoreService.pageKey.value === key

    return {
      key,
      text,
      url,
      children,
      selected,
    } as AppNavComponentItem
  }

  return { ...data }
}
