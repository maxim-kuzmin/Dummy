import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import {
  HttpHeaderNames,
  type HttpRequestOptions,
} from '~/utils/shared/http/http.types'
import { getAppIndexPageService } from '../app-index-page.service'
import type { AppIndexPageStoreModel } from './app-index-page-store.types'
import type { AppIndexPageData } from '../app-index-page.types'

//const storeKey = 'app-index-page'
const storeUrl = '/api/app-index-page-api'

export const useAppIndexPageStore = (): AppIndexPageStoreModel => {
  const pageStoreModel = usePageStore()

  const appIndexPageService = getAppIndexPageService()

  return {
    async load(options: HttpRequestOptions): Promise<void> {
      const appIndexPageKey = appIndexPageService.createPageKey(options.locale)

      pageStoreModel.pageKey.value = appIndexPageKey

      const headers = {
        [HttpHeaderNames.locale]: options.locale,
      }

      const res = await useFetch<AppIndexPageData>(storeUrl, {
        headers,
        key: appIndexPageKey,
      })

      const value = res.data.value!

      pageStoreModel.pageTitle.value = value.pageTitle
    },
  }
}
