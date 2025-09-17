import type { LocationQueryRaw } from 'vue-router'
import type { PageUrlOptions } from '~/utils/shared/page/url/page-url.types'
import {
  AppFakePageParameters,
  type AppFakePageDataQuery,
} from './app-fake-page.types'

export class AppFakePageService {
  readonly parameters = new AppFakePageParameters()

  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): PageUrlOptions {
    let locationQuery: LocationQueryRaw | undefined

    const withPageNumber =
      dataQuery.pageNumber > this.parameters.pageNumber.defaultValue

    const hasLocationQuery = withPageNumber

    if (hasLocationQuery) {
      locationQuery = {}

      if (withPageNumber) {
        locationQuery[this.parameters.pageNumber.name] = dataQuery.pageNumber
      }
    }

    return {
      routeName: 'fake-id',
      routeParams: {
        [this.parameters.id.name]: dataQuery.id,
      },
      locationQuery,
    }
  }
}

const appFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return appFakePageService
}
