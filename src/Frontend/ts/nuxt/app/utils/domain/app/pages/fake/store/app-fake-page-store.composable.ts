import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { HttpHeaderNames, type HttpRequestOptions } from '~/utils/shared/http/http.types'
import { getAppFakePageService } from '../app-fake-page.service'
import { AppFakePageParameters, type AppFakePageData, type AppFakePageDataQuery } from '../app-fake-page.types'
import type { AppFakePageStoreModel } from './app-fake-page-store.types'

const storeKey = 'app-fake-page'
const storeUrl = '/api/app-fake-page-api'

export const useAppFakePageStore = (): AppFakePageStoreModel => {
  const pageStoreModel = usePageStore()

  const appFakePageService = getAppFakePageService()

  const clickCount = useState(`${storeKey}.clickCount`, () => 0)
  const pageKey = useState(`${storeKey}.pageKey`, () => '')

  return {
    clickCount,
    pageKey,
    incrementClickCount(): void {
      clickCount.value++
    },
    async load(dataQuery: AppFakePageDataQuery, options: HttpRequestOptions): Promise<void> {
      const appFakePageKey = appFakePageService.createPageKey(dataQuery, options.locale)

      pageStoreModel.pageKey.value = appFakePageKey

      const query = {
        [AppFakePageParameters.id.name]: dataQuery.id,
        [AppFakePageParameters.pageNumber.name]: dataQuery.pageNumber
      }

      const headers = {
        [HttpHeaderNames.locale]: options.locale
      }

      const res = await useFetch<AppFakePageData>(storeUrl, { query, headers, key: appFakePageKey })

      const value = res.data.value!

      pageStoreModel.pageTitle.value = value.pageTitle

      pageKey.value = appFakePageKey
    },
  }
}
