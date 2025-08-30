import { LOCALE_ID, Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  private localeId = inject(LOCALE_ID);

  ruLanguageKey = 'ru';
  enLanguageKey = 'en';

  private languageLookup;

  constructor() {
    this.languageLookup = new Map([
      [this.enLanguageKey, 'English'],
      [this.ruLanguageKey, 'Русский'],
    ]);
  }

  getCurrentLanguageKey(): string {
    return this.localeId;
  }

  getCurrentLanguageValue(): string {
    return this.getLanguageValueByKey(this.getCurrentLanguageKey());
  }

  getLanguageValueByKey(languageKey: string): string {
    return this.languageLookup.get(languageKey)!;
  }

  createLocalizedUrl(languageKey: string, url: string): string {
    return languageKey === this.ruLanguageKey ? url : `/${languageKey}${url}`;
  }
}
