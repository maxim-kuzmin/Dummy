import { inject } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppNotFoundPageService } from './app-not-found-page.service';

export class AppNotFoundPageModel {
  private readonly appNotFoundPageService = inject(AppNotFoundPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(): void {
    this.pageStoreService.pageKey.set(this.appNotFoundPageService.createPageKey());
    this.pageStoreService.pageTitle.set($localize`:@@app.pages.app-not-found-page.title:@@`);
  }
}
