import { HttpHeaderNames } from '~/utils/shared/http/http.types'
import type { AppNotFoundPageApiDataOptions } from './app-not-found-page-api.types'

export class AppNotFoundPageApiService {
  createFetchOptions(
    dataOptions: AppNotFoundPageApiDataOptions,
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

const appNotFoundPageApiService = new AppNotFoundPageApiService()

export function getAppNotFoundPageApiService(): AppNotFoundPageApiService {
  return appNotFoundPageApiService
}
