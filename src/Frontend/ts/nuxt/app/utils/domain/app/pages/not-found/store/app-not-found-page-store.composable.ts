import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import {
  HttpHeaderNames,
  type HttpRequestOptions,
} from '~/utils/shared/http/http.types'
import { getAppNotFoundPageService } from '../app-not-found-page.service'
import type { AppNotFoundPageStoreModel } from './app-not-found-page-store.types'
import type { AppNotFoundPageData } from '../app-not-found-page.types'

//const storeKey = 'app-not-found-page'
const storeUrl = '/api/app-not-found-page-api'

export const useAppNotFoundPageStore = (): AppNotFoundPageStoreModel => {
  const pageStoreModel = usePageStore()

  const appNotFoundPageService = getAppNotFoundPageService()

  return {
    async load(options: HttpRequestOptions): Promise<void> {
      const appNotFoundPageKey = appNotFoundPageService.createPageKey(options.locale)

      pageStoreModel.pageKey.value = appNotFoundPageKey

      const headers = {
        [HttpHeaderNames.locale]: options.locale,
      }

      const res = await useFetch<AppNotFoundPageData>(storeUrl, {
        headers,
        key: appNotFoundPageKey,
      })

      const value = res.data.value!

      pageStoreModel.pageTitle.value = value.pageTitle
    },
  }
}
