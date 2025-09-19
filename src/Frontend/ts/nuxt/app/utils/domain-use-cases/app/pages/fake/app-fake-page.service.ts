import type {
  PageUrlOptions,
  PageUrlQueryParams,
} from '~/utils/infrastructure/page/url/page-url.types'
import {
  appFakePageParameters,
  type AppFakePageDataQuery,
} from './app-fake-page.types'

export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): PageUrlOptions {
    const queryParams = {} as PageUrlQueryParams

    if (dataQuery.pageNumber > appFakePageParameters.pageNumber.defaultValue) {
      queryParams[appFakePageParameters.pageNumber.name] = dataQuery.pageNumber
    }

    return {
      routeName: 'fake-id',
      routeParams: {
        [appFakePageParameters.id.name]: dataQuery.id,
      },
      queryParams,
    }
  }
}

const appFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return appFakePageService
}
