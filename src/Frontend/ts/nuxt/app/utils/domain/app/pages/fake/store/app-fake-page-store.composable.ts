import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import type { PageData } from '~/utils/shared/page/page.types'
import { AppFakePageParameters, type AppFakePageDataQuery } from '../app-fake-page.types'
import type { AppFakePageStoreModel } from './app-fake-page-store.types'
import { HttpHeaderNames, type HttpRequestOptions } from '~/utils/shared/http/http.types'
import { getAppFakePageService } from '../app-fake-page.service'

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
    click(): void {
      clickCount.value++
    },
    async load(dataQuery: AppFakePageDataQuery, options: HttpRequestOptions): Promise<void> {
      pageKey.value = appFakePageService.createPageKey(dataQuery, options.locale)

      pageStoreModel.pageKey.value = pageKey.value

      const query = {
        [AppFakePageParameters.id.name]: dataQuery.id,
        [AppFakePageParameters.pageNumber.name]: dataQuery.pageNumber
      }

      const headers = {
        [HttpHeaderNames.locale]: options.locale
      }

      const res = await useFetch<PageData>(storeUrl, { query, headers, key: pageKey.value })

      const value = res.data.value!

      pageStoreModel.pageTitle.value = value.pageTitle
    },
  }
}
