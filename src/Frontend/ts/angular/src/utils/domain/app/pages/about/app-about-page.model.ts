import { inject } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppAboutPageService } from './app-about-page.service';

export class AppAboutPageModel {
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(): void {
    this.pageStoreService.pageKey.set(this.appAboutPageService.createPageKey());
    this.pageStoreService.pageTitle.set($localize`:@@app.pages.app-about-page.title:@@`);
  }
}
