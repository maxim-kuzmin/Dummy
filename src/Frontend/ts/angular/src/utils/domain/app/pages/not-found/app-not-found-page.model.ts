import { inject } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppNotFoundPageResourcesService } from './resources/app-not-found-page-resources.service';
import { AppNotFoundPageService } from './app-not-found-page.service';

export class AppNotFoundPageModel {
  private readonly appNotFoundPageResourcesService = inject(
    AppNotFoundPageResourcesService
  );

  private readonly appNotFoundPageService = inject(AppNotFoundPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(): void {
    this.pageStoreService.pageKey.set(this.appNotFoundPageService.createPageKey());

    this.pageStoreService.pageTitle.set(this.appNotFoundPageResourcesService.getTitle());
  }
}
