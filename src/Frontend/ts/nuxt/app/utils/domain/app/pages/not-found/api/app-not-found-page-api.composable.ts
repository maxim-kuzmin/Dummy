import { getAppNotFoundPageService } from '../app-not-found-page.service'
import { getAppNotFoundPageApiService } from './app-not-found-page-api.service'
import type {
  AppNotFoundPageApiData,
  AppNotFoundPageApiDataOptions,
  AppNotFoundPageApiModel,
} from './app-not-found-page-api.types'

const apiUrl = '/api/app-not-found-page-api'

export const useAppNotFoundPageApi = (): AppNotFoundPageApiModel => {
  const appNotFoundPageService = getAppNotFoundPageService()
  const appNotFoundPageApiService = getAppNotFoundPageApiService()

  return {
    async get(
      dataOptions: AppNotFoundPageApiDataOptions,
    ): Promise<AppNotFoundPageApiData> {
      const key = appNotFoundPageService.createPageKey(dataOptions.locale)

      const fetchOptions = appNotFoundPageApiService.createFetchOptions(
        dataOptions,
        key,
      )

      const res = await useFetch<AppNotFoundPageApiData>(apiUrl, fetchOptions)

      return res.data.value!
    },
  }
}
