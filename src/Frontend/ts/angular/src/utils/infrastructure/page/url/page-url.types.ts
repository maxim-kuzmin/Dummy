import { Params } from '@angular/router';

export type PageUrlQueryParams = Params;

export type PageUrlRouteParams = readonly any[];

export interface PageUrlOptions {
  readonly routeParams: PageUrlRouteParams;
  readonly queryParams?: PageUrlQueryParams;
}
