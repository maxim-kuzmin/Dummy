import { inject } from '@angular/core';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { AppAboutPageStoreService } from './store/app-about-page-store.service';

export class AppAboutPageModel {
  private readonly appAboutPageStoreService = inject(AppAboutPageStoreService);
  private readonly languageService = inject(LanguageService);

  load(): void {
    const locale = this.languageService.getCurrentLanguage().code;

    this.appAboutPageStoreService.load({ locale });
  }
}
