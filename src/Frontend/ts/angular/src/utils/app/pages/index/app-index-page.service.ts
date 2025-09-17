import { Injectable } from '@angular/core';
import { PageUrlOptions } from '~/utils/shared/page/url/page-url.types';

@Injectable({
  providedIn: 'root',
})
export class AppIndexPageService {
  createPageKey(): string {
    return 'Index';
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeParams: ['/'],
    };
  }
}
