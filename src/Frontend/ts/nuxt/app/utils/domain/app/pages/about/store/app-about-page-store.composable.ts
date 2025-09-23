import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import {
  HttpHeaderNames,
  type HttpRequestOptions,
} from '~/utils/shared/http/http.types'
import { getAppAboutPageService } from '../app-about-page.service'
import type { AppAboutPageData } from '../app-about-page.types'
import type { AppAboutPageStoreModel } from './app-about-page-store.types'

//const storeKey = 'app-about-page'
const storeUrl = '/api/app-about-page-api'

export const useAppAboutPageStore = (): AppAboutPageStoreModel => {
  const pageStoreModel = usePageStore()

  const appAboutPageService = getAppAboutPageService()

  return {
    async load(options: HttpRequestOptions): Promise<void> {
      const appAboutPageKey = appAboutPageService.createPageKey(options.locale)

      pageStoreModel.pageKey.value = appAboutPageKey

      const headers = {
        [HttpHeaderNames.locale]: options.locale,
      }

      const res = await useFetch<AppAboutPageData>(storeUrl, {
        headers,
        key: appAboutPageKey,
      })

      const value = res.data.value!

      pageStoreModel.pageTitle.value = value.pageTitle
    },
  }
}
