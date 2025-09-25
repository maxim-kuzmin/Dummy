import { inject } from '@angular/core';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { AppNotFoundPageStoreService } from './store/app-not-found-page-store.service';

export class AppNotFoundPageModel {
  private readonly appNotFoundPageStoreService = inject(AppNotFoundPageStoreService);
  private readonly languageService = inject(LanguageService);

  load(): void {
    const locale = this.languageService.getCurrentLanguage().code;

    this.appNotFoundPageStoreService.load({ locale });
  }
}
