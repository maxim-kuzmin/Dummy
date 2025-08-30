import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  ruLanguageKey = 'ru';
  enLanguageKey = 'en';

  languageLookup = new Map([
    [this.enLanguageKey, 'English'],
    [this.ruLanguageKey, 'Русский'],
  ]);

  getUrl(languageKey: string): string {
    return languageKey === this.ruLanguageKey ? '/' : `/${languageKey}`;
  }
}
