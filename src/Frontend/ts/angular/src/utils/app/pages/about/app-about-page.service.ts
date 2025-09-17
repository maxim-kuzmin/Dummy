import { Injectable } from '@angular/core';
import { PageUrlOptions } from '~/utils/shared/page/url/page-url.types';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageService {
  createPageKey(): string {
    return 'About';
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeParams: ['/about'],
    };
  }
}
