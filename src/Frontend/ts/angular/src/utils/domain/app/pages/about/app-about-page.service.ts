import { Injectable } from '@angular/core';
import { UrlOptions } from '~/utils/infrastructure/url/url.types';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageService {
  createPageKey(): string {
    return 'About';
  }

  createPageUrlOptions(): UrlOptions {
    return {
      routeParams: ['/about'],
    };
  }
}
