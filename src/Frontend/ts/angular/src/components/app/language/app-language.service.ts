import { inject, Injectable, signal } from '@angular/core';
import { ComponentData, Language } from './app-language.types';
import { LanguageService } from '~shared/language/language.service';

@Injectable({
  providedIn: 'root',
})
export class AppLanguageService {
  private readonly languageService = inject(LanguageService);

  readonly componentData = {
    currentLanguageValue: '',
    languages: signal([]),
  } as ComponentData;

  loadComponentData(currentUrl: string) {
    this.componentData.currentLanguageValue = this.languageService.getCurrentLanguageValue();

    this.componentData.languages.set(this.createLanguages(currentUrl));
  }

  private createLanguage(
    key: string,
    currentLanguageKey: string,
    currentUrl: string
  ): Language {
    const value = this.languageService.getLanguageValueByKey(key);
    const url = this.languageService.createLocalizedUrl(key, currentUrl);
    const selected = key === currentLanguageKey;

    return {
      key,
      value,
      url,
      selected,
    } as Language;
  }

  private createLanguages(currentUrl: string): Language[] {
    const currentLanguageKey = this.languageService.getCurrentLanguageKey();

    return [
      this.createLanguage(
        this.languageService.ruLanguageKey,
        currentLanguageKey,
        currentUrl
      ),
      this.createLanguage(
        this.languageService.enLanguageKey,
        currentLanguageKey,
        currentUrl
      ),
    ];
  }
}
