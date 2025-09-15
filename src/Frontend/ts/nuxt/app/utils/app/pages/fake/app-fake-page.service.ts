import { getPageService } from '~/utils/shared/page/page.service'
import type { PageUrlOptions } from '~/utils/shared/page/page.types'
import {
  AppFakePageData,
  type AppFakePagePayload,
  type AppFakePageDataQuery,
  type AppFakePageParameterNames,
} from './app-fake-page.types'
import type { LocationQueryRaw } from 'vue-router'

export class AppFakePageService {
  private readonly pageService = getPageService()

  readonly pageData = new AppFakePageData()

  readonly parameterNames = {
    id: 'id',
    pageNumber: 'pn'
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

  loadPageData(payload: AppFakePagePayload): void {
    const { dataQuery, resources } = payload

    const pageKey = this.createPageKey(dataQuery)

    this.pageService.key.value = pageKey
    this.pageService.title.value = resources.title

    this.pageData.key.value = pageKey
  }
}

const instanceOfAppFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return instanceOfAppFakePageService
}
