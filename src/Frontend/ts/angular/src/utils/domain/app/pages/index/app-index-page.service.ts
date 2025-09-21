import { Injectable } from '@angular/core';
import { UrlOptions } from '~/utils/infrastructure/url/url.types';

@Injectable({
  providedIn: 'root',
})
export class AppIndexPageService {
  createPageKey(): string {
    return 'Index';
  }

  createPageUrlOptions(): UrlOptions {
    return {
      routeParams: ['/'],
    };
  }
}
