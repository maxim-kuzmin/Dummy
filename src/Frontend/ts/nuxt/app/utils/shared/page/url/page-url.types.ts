import type { LocationQueryRaw, RouteParamsRawGeneric } from "vue-router"

export interface PageUrlOptions {
  readonly routeName: string
  readonly routeParams?: RouteParamsRawGeneric
  readonly locationQuery?: LocationQueryRaw
}
