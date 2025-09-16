import type { LocationQueryRaw } from 'vue-router'
import type { PageUrlOptions } from '~/utils/shared/page/url/page-url.types'
import type {
  AppFakePageDataQuery,
  AppFakePageParameterNames,
} from './app-fake-page.types'

export class AppFakePageService {
  readonly parameterNames = {
    id: 'id',
    pageNumber: 'pn',
  } as AppFakePageParameterNames

  createPageKey(query: AppFakePageDataQuery): string {
    return `Fake:${query.id},${query.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): PageUrlOptions {
    let locationQuery: LocationQueryRaw | undefined

    const hasLocationQuery = dataQuery.pageNumber > 1

    if (hasLocationQuery) {
      locationQuery = {}

      if (dataQuery.pageNumber > 1) {
        locationQuery[this.parameterNames.pageNumber] = dataQuery.pageNumber
      }
    }

    return {
      routeName: 'fake-id',
      routeParams: {
        [this.parameterNames.id]: dataQuery.id,
      },
      locationQuery,
    }
  }
}

const appFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return appFakePageService
}
