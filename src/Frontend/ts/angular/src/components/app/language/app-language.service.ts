import { inject, Injectable, signal } from '@angular/core';
import { ComponentData, Language } from './app-language.types';
import { LanguageService } from '~/utils/shared/language/language.service';

@Injectable({
  providedIn: 'root',
})
export class AppLanguageService {
  private readonly languageService = inject(LanguageService);

  readonly componentData = {
    currentLanguageName: '',
    languages: signal([]),
  } as ComponentData;

  loadComponentData(currentUrl: string) {
    this.componentData.currentLanguageName = this.languageService.getCurrentLanguageName();

    this.componentData.languages.set(this.createLanguages(currentUrl));
  }

  private createLanguage(
    code: string,
    currentLanguageCode: string,
    currentUrl: string
  ): Language {
    const name = this.languageService.getLanguageNameByCode(code);
    const url = this.languageService.createLocalizedUrl(code, currentUrl);
    const selected = code === currentLanguageCode;

    return {
      code,
      name,
      url,
      selected,
    } as Language;
  }

  private createLanguages(currentUrl: string): Language[] {
    const currentLanguageCode = this.languageService.getCurrentLanguageCode();

    return [
      this.createLanguage(
        this.languageService.ruLanguageCode,
        currentLanguageCode,
        currentUrl
      ),
      this.createLanguage(
        this.languageService.enLanguageCode,
        currentLanguageCode,
        currentUrl
      ),
    ];
  }
}
