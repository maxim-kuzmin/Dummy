import { HttpHeaderNames } from '~/utils/shared/http/http.types'
import type { AppIndexPageApiDataOptions } from './app-index-page-api.types'

export class AppIndexPageApiService {
  createFetchOptions(
    dataOptions: AppIndexPageApiDataOptions,
    key: string,
  ): Record<string, unknown> {
    return {
      headers: {
        [HttpHeaderNames.locale]: dataOptions.locale,
      },
      key,
    }
  }
}

const appIndexPageApiService = new AppIndexPageApiService()

export function getAppIndexPageApiService(): AppIndexPageApiService {
  return appIndexPageApiService
}
