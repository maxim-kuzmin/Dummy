import { Injectable } from '@angular/core';
import { PageUrlOptions } from '~/utils/infrastructure/page/url/page-url.types';
import { LanguageCode } from '~/utils/shared/language/language.types';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageService {
  createPageKey(languageCode: LanguageCode): string {
    return `About:${languageCode}`
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeParams: ['/about'],
    };
  }
}
