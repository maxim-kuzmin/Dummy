import type { LanguageCode } from '~/utils/shared/language/language.types'
import type {
  PageUrlOptions,
  PageUrlQueryParams,
} from '~/utils/infrastructure/page/url/page-url.types'
import {
  AppFakePageParameters,
} from './app-fake-page.types'
import type { AppFakePageApiDataQuery } from './api/app-fake-page-api.types'

export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageApiDataQuery, languageCode: LanguageCode): string {
    return `Fake:${languageCode},${dataQuery.id},${dataQuery.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageApiDataQuery): PageUrlOptions {
    const queryParams = {} as PageUrlQueryParams

    if (dataQuery.pageNumber > AppFakePageParameters.pageNumber.defaultValue) {
      queryParams[AppFakePageParameters.pageNumber.name] = dataQuery.pageNumber
    }

    return {
      routeName: 'fake-id',
      routeParams: {
        [AppFakePageParameters.id.name]: dataQuery.id,
      },
      queryParams,
    }
  }
}

const appFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return appFakePageService
}
