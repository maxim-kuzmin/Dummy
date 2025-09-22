import type {
  UrlOptions,
  PageUrlQueryParams,
} from '~/utils/infrastructure/page/url/page-url.types'
import {
  AppFakePageParameters,
  type AppFakePageDataQuery,
} from './app-fake-page.types'
import type { LanguageCode } from '~/utils/shared/language/language.types'

export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageDataQuery, languageCode: LanguageCode): string {
    return `Fake:${languageCode},${dataQuery.id},${dataQuery.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): UrlOptions {
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
