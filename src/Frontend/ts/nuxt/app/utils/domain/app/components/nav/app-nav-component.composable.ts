import { getAppAboutPageService } from '~/utils/domain/app/pages/about/app-about-page.service'
import { getAppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service'
import { useUrl } from '~/utils/infrastructure/url/url.composable'
import { usePage } from '~/utils/infrastructure/page/page.composable'
import type { AppFakePageDataQuery } from '../../pages/fake/app-fake-page.types'
import { useAppAboutPageResources } from '../../pages/about/resources/app-about-page-resources.composable'
import type { AppNavComponentItem, AppNavComponentModel } from './app-nav-component.types'

const storeKey = 'app-nav-component'

export const useAppNavComponent = (): AppNavComponentModel => {
  const appAboutPageResourcesModel = useAppAboutPageResources()
  const pageModel = usePage()

  const appAboutPageService = getAppAboutPageService()
  const appFakePageService = getAppFakePageService()

  const items = useState<AppNavComponentItem[]>(`${storeKey}.items`, () => [])

  onServerPrefetch(load)

  watchEffect(load)

  function load() {
    //const pageKey = pageModel.pageKey.value

    items.value = createFakeItems()
    //selectItem(pageKey, items.value)
  }

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

    const url = useUrl(appAboutPageService.createPageUrlOptions())

    return createItem(key, url, text)
  }

  function createItemForFakePage(
    text: string,
    children: AppNavComponentItem[] = [],
  ): AppNavComponentItem {
    const dataQuery = { id: text, pageNumber: 1 } as AppFakePageDataQuery

    const key = appFakePageService.createPageKey(dataQuery)

    const url = useUrl(appFakePageService.createPageUrlOptions(dataQuery))

    return createItem(key, url, text, children)
  }

  function createItemForFakePageByDataQuery(
    dataQuery: AppFakePageDataQuery,
    children: AppNavComponentItem[] = [],
  ): AppNavComponentItem {
    const key = appFakePageService.createPageKey(dataQuery)

    const url = useUrl(appFakePageService.createPageUrlOptions(dataQuery))

    return createItem(key, url, key, children)
  }

  function createItem(
    key: string,
    url: string,
    text: string,
    children: AppNavComponentItem[] = [],
  ): AppNavComponentItem {
    return {
      key,
      text,
      url,
      children,
      selected: key === pageModel.pageKey.value,
    } as AppNavComponentItem
  }

  // function selectItem(pageKey: string, items: AppNavComponentItem[]) {
  //   items.forEach(item => {
  //     item.selected = item.key === pageKey

  //     if (item.children.length > 0) {
  //       selectItem(pageKey, item.children)
  //     }
  //   });
  // }

  return { items }
}
