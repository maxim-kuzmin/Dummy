import { Injectable } from '@angular/core';
import {
  AppFakePageDataQuery,
  appFakePageParameters,
} from './app-fake-page.types';
import {
  PageUrlOptions,
  PageUrlQueryParams,
} from '~/utils/infrastructure/page/url/page-url.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageService {
  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`;
  }

  createPageUrlOptions(dataQuery: AppFakePageDataQuery): PageUrlOptions {
    const queryParams = {} as PageUrlQueryParams;

    if (dataQuery.pageNumber > appFakePageParameters.pageNumber.defaultValue) {
      queryParams[appFakePageParameters.pageNumber.name] = dataQuery.pageNumber;
    }

    return {
      routeParams: ['/fake', dataQuery.id],
      queryParams,
    };
  }
}
