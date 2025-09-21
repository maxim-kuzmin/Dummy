import type {
  UrlOptions,
  UrlQueryParams,
} from '~/utils/infrastructure/url/url.types'
import {
  AppFakePageParameters,
  type AppFakePageDataQuery,
} from './app-fake-page.types'

export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): UrlOptions {
    const queryParams = {} as UrlQueryParams

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
