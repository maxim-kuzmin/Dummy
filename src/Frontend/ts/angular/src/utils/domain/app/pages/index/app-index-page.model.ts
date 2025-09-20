import { inject } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppIndexPageService } from './app-index-page.service';

export class AppIndexPageModel {
  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(): void {
    this.pageStoreService.pageKey.set(this.appIndexPageService.createPageKey());
    this.pageStoreService.pageTitle.set($localize`:@@app.pages.app-index-page.title:@@`);
  }
}
