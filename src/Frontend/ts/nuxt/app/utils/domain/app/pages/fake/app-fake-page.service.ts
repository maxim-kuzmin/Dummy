import type {
  PageUrlOptions,
  PageUrlQueryParams,
} from '~/utils/infrastructure/page/url/page-url.types'
import {
  AppFakePageParameters,
  type AppFakePageDataQuery,
} from './app-fake-page.types'

export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): PageUrlOptions {
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
