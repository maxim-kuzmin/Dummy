import { inject } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppIndexPageResourcesService } from './resources/app-index-page-resources.service';
import { AppIndexPageService } from './app-index-page.service';

export class AppIndexPageModel {
  private readonly appIndexPageResourcesService = inject(
    AppIndexPageResourcesService
  );

  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(): void {
    this.pageStoreService.pageKey.set(this.appIndexPageService.createPageKey());

    this.pageStoreService.pageTitle.set(
      this.appIndexPageResourcesService.getTitle()
    );
  }
}
