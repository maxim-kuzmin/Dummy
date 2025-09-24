import { getAppAboutPageService } from '../app-about-page.service'
import { getAppAboutPageApiService } from './app-about-page-api.service'
import type {
  AppAboutPageApiData,
  AppAboutPageApiDataOptions,
  AppAboutPageApiModel,
} from './app-about-page-api.types'

const apiUrl = '/api/app-about-page-api'

export const useAppAboutPageApi = (): AppAboutPageApiModel => {
  const appAboutPageService = getAppAboutPageService()
  const appAboutPageApiService = getAppAboutPageApiService()

  return {
    async get(
      dataOptions: AppAboutPageApiDataOptions,
    ): Promise<AppAboutPageApiData> {
      const key = appAboutPageService.createPageKey(dataOptions.locale)

      const fetchOptions = appAboutPageApiService.createFetchOptions(
        dataOptions,
        key,
      )

      const res = await useFetch<AppAboutPageApiData>(apiUrl, fetchOptions)

      return res.data.value!
    },
  }
}
