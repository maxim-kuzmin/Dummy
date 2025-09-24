import { HttpHeaderNames } from '~/utils/shared/http/http.types'
import type { AppAboutPageApiDataOptions } from './app-about-page-api.types'

export class AppAboutPageApiService {
  createFetchOptions(
    dataOptions: AppAboutPageApiDataOptions,
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

const appAboutPageApiService = new AppAboutPageApiService()

export function getAppAboutPageApiService(): AppAboutPageApiService {
  return appAboutPageApiService
}
