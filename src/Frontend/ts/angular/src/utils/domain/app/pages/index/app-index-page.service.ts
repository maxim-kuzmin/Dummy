import { Injectable } from '@angular/core';
import { PageUrlOptions } from '~/utils/infrastructure/page/url/page-url.types';
import { LanguageCode } from '~/utils/shared/language/language.types';

@Injectable({
  providedIn: 'root',
})
export class AppIndexPageService {
  createPageKey(languageCode: LanguageCode): string {
    return `Index:${languageCode}`
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeParams: ['/'],
    };
  }
}
