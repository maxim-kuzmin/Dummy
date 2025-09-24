import { getAppIndexPageService } from '../app-index-page.service'
import { getAppIndexPageApiService } from './app-index-page-api.service'
import type {
  AppIndexPageApiData,
  AppIndexPageApiDataOptions,
  AppIndexPageApiModel,
} from './app-index-page-api.types'

const apiUrl = '/api/app-index-page-api'

export const useAppIndexPageApi = (): AppIndexPageApiModel => {
  const appIndexPageService = getAppIndexPageService()
  const appIndexPageApiService = getAppIndexPageApiService()

  return {
    async get(
      dataOptions: AppIndexPageApiDataOptions,
    ): Promise<AppIndexPageApiData> {
      const key = appIndexPageService.createPageKey(dataOptions.locale)

      const fetchOptions = appIndexPageApiService.createFetchOptions(
        dataOptions,
        key,
      )

      const res = await useFetch<AppIndexPageApiData>(apiUrl, fetchOptions)

      return res.data.value!
    },
  }
}
