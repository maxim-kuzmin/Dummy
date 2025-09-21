import { Params } from '@angular/router';

export type UrlQueryParams = Params;

export type UrlRouteParams = readonly any[];

export interface UrlOptions {
  readonly routeParams: UrlRouteParams;
  readonly queryParams?: UrlQueryParams;
}
