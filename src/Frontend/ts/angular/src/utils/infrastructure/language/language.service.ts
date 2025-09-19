import { LOCALE_ID, Injectable, inject, isDevMode } from '@angular/core';
import { Language, LanguageCode, languages } from '../../shared/language/language.types';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  private readonly localeId = inject(LOCALE_ID);

  createLocalizedUrl(code: LanguageCode, url: string): string {
    if (isDevMode()) {
      return url;
    } else {
      return code === languages.russian.code ? url : `/${code}${url}`;
    }
  }

  getCurrentLanguage(): Language {
    switch (this.localeId) {
      case languages.english.code:
        return languages.english;
      case languages.russian.code:
      default:
        return languages.russian;
    }
  }
}
