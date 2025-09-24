import { getAppAboutPageService } from '~/utils/domain/app/pages/about/app-about-page.service'
import type { AppFakePageApiDataQuery } from '~/utils/domain/app/pages/fake/api/app-fake-page-api.types'
import { getAppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service'
import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { usePageUrl } from '~/utils/infrastructure/page/url/page-url.composable'
import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useClientResources } from '~/utils/infrastructure/resources/client-resources.composable'
import { useAppAboutPageResources } from '~/utils/domain/app/pages/about/resources/app-about-page-resources.composable'
import { useAppFakePageResources } from '~/utils/domain/app/pages/fake/resources/app-fake-page-resources.composable'
import type { AppNavComponentItem } from '../../app-nav-component.types'
import type { AppNavIndexComponentStoreModel } from './app-nav-index-component-store.types'

const storeKey = 'app-nav-index-component'

export const useAppNavIndexComponentStore =
  (): AppNavIndexComponentStoreModel => {
    const resourcesModel = useClientResources()
    const appAboutPageResourcesModel = useAppAboutPageResources(resourcesModel)
    const appFakePageResourcesModel = useAppFakePageResources(resourcesModel)
    const languageModel = useLanguage()
    const pageStoreModel = usePageStore()

    const appAboutPageService = getAppAboutPageService()
    const appFakePageService = getAppFakePageService()

    const items = useState<AppNavComponentItem[]>(`${storeKey}.items`, () => [])

    const languageCode = computed(() => languageModel.getCurrentLanguage().code)

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

      const key = appAboutPageService.createPageKey(languageCode.value)

      const url = usePageUrl(appAboutPageService.createPageUrlOptions())

      return createItem(key, url, text)
    }

    function createItemForFakePage(
      id: string,
      children: AppNavComponentItem[] = [],
    ): AppNavComponentItem {
      const text = appFakePageResourcesModel.getTitle(id, 1)

      const dataQuery = { id: id, pageNumber: 1 } as AppFakePageApiDataQuery

      const key = appFakePageService.createPageKey(
        dataQuery,
        languageCode.value,
      )

      const url = usePageUrl(appFakePageService.createPageUrlOptions(dataQuery))

      return createItem(key, url, text, children)
    }

    function createItemForFakePageByDataQuery(
      dataQuery: AppFakePageApiDataQuery,
      children: AppNavComponentItem[] = [],
    ): AppNavComponentItem {
      const text = appFakePageResourcesModel.getTitle(
        dataQuery.id,
        dataQuery.pageNumber,
      )

      const key = appFakePageService.createPageKey(
        dataQuery,
        languageCode.value,
      )

      const url = usePageUrl(appFakePageService.createPageUrlOptions(dataQuery))

      return createItem(key, url, text, children)
    }

    function createItem(
      key: string,
      url: string,
      text: string,
      children: AppNavComponentItem[] = [],
    ): AppNavComponentItem {
      return {
        key,
        text: ref(text),
        url: ref(url),
        children: ref(children),
        selected: computed(() => key === pageStoreModel.pageKey.value),
      } as unknown as AppNavComponentItem
    }

    return {
      items: readonly(items),
      load(): void {
        items.value = createFakeItems()
      },
    } as AppNavIndexComponentStoreModel
  }
