import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppFakePageApi } from '../api/app-fake-page-api.composable'
import type {
  AppFakePageApiDataOptions,
  AppFakePageApiDataQuery,
} from '../api/app-fake-page-api.types'
import { getAppFakePageService } from '../app-fake-page.service'
import type { AppFakePageStoreModel } from './app-fake-page-store.types'

const storeKey = 'app-fake-page'

export const useAppFakePageStore = (): AppFakePageStoreModel => {
  const appFakePageApiModel = useAppFakePageApi()
  const pageStoreModel = usePageStore()

  const appFakePageService = getAppFakePageService()

  const clickCount = useState(`${storeKey}.clickCount`, () => 0)
  const pageKey = useState(`${storeKey}.pageKey`, () => '')

  return {
    clickCount: readonly(clickCount),
    pageKey: readonly(pageKey),
    incrementClickCount(): void {
      clickCount.value++
    },
    async load(
      dataQuery: AppFakePageApiDataQuery,
      dataOptions: AppFakePageApiDataOptions,
    ): Promise<void> {
      const data = await appFakePageApiModel.get(dataQuery, dataOptions)

      pageStoreModel.load({
        pageKey: appFakePageService.createPageKey(
          dataQuery,
          dataOptions.locale,
        ),
        pageTitle: data.pageTitle,
      })

      pageKey.value = pageStoreModel.pageKey.value
    },
  }
}
