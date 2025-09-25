import { inject } from '@angular/core';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { AppIndexPageStoreService } from './store/app-index-page-store.service';

export class AppIndexPageModel {
  private readonly appIndexPageStoreService = inject(AppIndexPageStoreService);
  private readonly languageService = inject(LanguageService);

  load(): void {
    const locale = this.languageService.getCurrentLanguage().code;

    this.appIndexPageStoreService.load({ locale });
  }
}
