import { Injectable } from '@angular/core';
import {
  PageUrlOptions,
  PageUrlQueryParams,
} from '~/utils/infrastructure/page/url/page-url.types';
import { LanguageCode } from '~/utils/shared/language/language.types';
import { AppFakePageParameters } from './app-fake-page.types';
import { AppFakePageApiDataQuery } from './api/app-fake-page-api.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageService {
  createPageKey(
    dataQuery: AppFakePageApiDataQuery,
    languageCode: LanguageCode
  ): string {
    return `Fake:${languageCode},${dataQuery.id},${dataQuery.pageNumber}`;
  }

  createPageUrlOptions(dataQuery: AppFakePageApiDataQuery): PageUrlOptions {
    const queryParams = {} as PageUrlQueryParams;

    if (dataQuery.pageNumber > AppFakePageParameters.pageNumber.defaultValue) {
      queryParams[AppFakePageParameters.pageNumber.name] = dataQuery.pageNumber;
    }

    return {
      routeParams: ['/fake', dataQuery.id],
      queryParams,
    };
  }
}
