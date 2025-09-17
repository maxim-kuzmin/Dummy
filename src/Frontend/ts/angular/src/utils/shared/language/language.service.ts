import { LOCALE_ID, Injectable, inject, isDevMode } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  private readonly localeId = inject(LOCALE_ID);

  readonly ruLanguageCode = 'ru';
  readonly enLanguageCode = 'en';

  private readonly languageNameLookup = new Map([
    [this.enLanguageCode, 'English'],
    [this.ruLanguageCode, 'Русский'],
  ]);

  getCurrentLanguageCode(): string {
    return this.localeId;
  }

  getCurrentLanguageName(): string {
    return this.getLanguageNameByCode(this.getCurrentLanguageCode());
  }

  getLanguageNameByCode(code: string): string {
    return this.languageNameLookup.get(code)!;
  }

  createLocalizedUrl(code: string, url: string): string {
    if (isDevMode()) {
      return url;
    } else {
      return code === this.ruLanguageCode ? url : `/${code}${url}`;
    }
  }
}
