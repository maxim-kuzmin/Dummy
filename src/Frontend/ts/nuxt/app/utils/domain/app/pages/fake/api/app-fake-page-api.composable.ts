import { getAppFakePageService } from '../app-fake-page.service'
import { getAppFakePageApiService } from './app-fake-page-api.service'
import type {
  AppFakePageApiData,
  AppFakePageApiDataOptions,
  AppFakePageApiDataQuery,
  AppFakePageApiModel,
} from './app-fake-page-api.types'

const apiUrl = '/api/app-fake-page-api'

export const useAppFakePageApi = (): AppFakePageApiModel => {
  const appFakePageService = getAppFakePageService()
  const appFakePageApiService = getAppFakePageApiService()

  return {
    async get(
      dataQuery: AppFakePageApiDataQuery,
      dataOptions: AppFakePageApiDataOptions,
    ): Promise<AppFakePageApiData> {
      const key = appFakePageService.createPageKey(dataQuery, dataOptions.locale)

      const fetchOptions = appFakePageApiService.createFetchOptions(
        dataQuery,
        dataOptions,
        key,
      )

      const res = await useFetch<AppFakePageApiData>(apiUrl, fetchOptions)

      return res.data.value!
    },
  }
}
