import { Injectable } from '@angular/core';
import {
  AppFakePageDataQuery,
  appFakePageParameters,
} from './app-fake-page.types';
import {
  UrlOptions,
  UrlQueryParams,
} from '~/utils/infrastructure/url/url.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`;
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): UrlOptions {
    const queryParams = {} as UrlQueryParams;

    if (dataQuery.pageNumber > appFakePageParameters.pageNumber.defaultValue) {
      queryParams[appFakePageParameters.pageNumber.name] = dataQuery.pageNumber;
    }

    return {
      routeParams: ['/fake', dataQuery.id],
      queryParams,
    };
  }
}
