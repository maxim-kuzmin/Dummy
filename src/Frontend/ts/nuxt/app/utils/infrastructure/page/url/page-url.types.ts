import type { LocationQueryRaw, RouteParamsRawGeneric } from 'vue-router'

export type PageUrlQueryParams = LocationQueryRaw

export type PageUrlRouteParams = RouteParamsRawGeneric

export interface PageUrlOptions {
  readonly routeName: string
  readonly routeParams?: PageUrlRouteParams
  readonly queryParams?: PageUrlQueryParams
}


