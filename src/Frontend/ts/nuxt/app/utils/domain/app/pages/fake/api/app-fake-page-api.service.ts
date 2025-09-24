import type { EventHandlerRequest, H3Event } from 'h3'
import type { RouteLocationNormalizedGeneric } from 'vue-router'
import { HttpHeaderNames } from '~/utils/shared/http/http.types'
import { AppFakePageParameters } from '../app-fake-page.types'
import type { AppFakePageApiDataOptions, AppFakePageApiDataQuery } from './app-fake-page-api.types'

export class AppFakePageApiService {
  createFetchOptions(
    dataQuery: AppFakePageApiDataQuery,
    dataOptions: AppFakePageApiDataOptions,
    key: string,
  ): Record<string, unknown> {
    return {
      query: {
        [AppFakePageParameters.id.name]: dataQuery.id,
        [AppFakePageParameters.pageNumber.name]: dataQuery.pageNumber,
      },
      headers: {
        [HttpHeaderNames.locale]: dataOptions.locale,
      },
      key,
    }
  }

  getDataQueryFromH3Event(
    event: H3Event<EventHandlerRequest>,
  ): AppFakePageApiDataQuery {
    const queryParams = getQuery(event)

    return {
      id: String(
        queryParams[AppFakePageParameters.id.name] ??
          AppFakePageParameters.id.defaultValue,
      ),
      pageNumber: Number(
        queryParams[AppFakePageParameters.pageNumber.name] ??
          AppFakePageParameters.pageNumber.defaultValue,
      ),
    }
  }

  getDataQueryFromRouteLocation(
    routeLocation: RouteLocationNormalizedGeneric,
  ): AppFakePageApiDataQuery {
    const routeParams = routeLocation.params
    const queryParams = routeLocation.query

    return {
      id: String(
        routeParams[AppFakePageParameters.id.name] ??
          AppFakePageParameters.id.defaultValue,
      ),
      pageNumber: Number(
        queryParams[AppFakePageParameters.pageNumber.name] ??
          AppFakePageParameters.pageNumber.defaultValue,
      ),
    }
  }
}

const appFakePageApiService = new AppFakePageApiService()

export function getAppFakePageApiService(): AppFakePageApiService {
  return appFakePageApiService
}
