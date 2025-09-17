import { inject, Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Router, UrlTree } from '@angular/router';
import { paths } from '~/utils/app/app.types';
import { LanguageService } from '~/utils/shared/language/language.service';
import {
  AppFakePageDataQuery,
  appFakePageParameters,
} from './app-fake-page.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageService {
  private readonly router = inject(Router);
  private readonly languageService = inject(LanguageService);

  createPageKey(dataQuery: AppFakePageDataQuery): string {
    return `Fake:${dataQuery.id},${dataQuery.pageNumber}`;
  }

  createPageUrl(dataQuery: AppFakePageDataQuery): string {
    let locationQuery = new HttpParams();

    if (dataQuery.pageNumber > appFakePageParameters.pageNumber.defaultValue) {
      locationQuery = locationQuery.append(
        appFakePageParameters.pageNumber.name,
        dataQuery.pageNumber
      );
    }

    const queryString = locationQuery.keys().length > 0 ? `?${locationQuery}` : '';

    const path = paths.fake.replace(`:${appFakePageParameters.id.name}`, dataQuery.id);

    return this.languageService.createLocalizedUrl(
      this.languageService.getCurrentLanguageCode(),
      `/${path}${queryString}`
    );
  }

  createPageUrlTree(dataQuery: AppFakePageDataQuery): UrlTree {
    return this.router.parseUrl(this.createPageUrl(dataQuery))
  }
}
