import type { LocationQueryRaw, RouteParamsRawGeneric } from 'vue-router'

export type UrlQueryParams = LocationQueryRaw

export type UrlRouteParams = RouteParamsRawGeneric

export interface UrlOptions {
  readonly routeName: string
  readonly routeParams?: UrlRouteParams
  readonly queryParams?: UrlQueryParams
}


