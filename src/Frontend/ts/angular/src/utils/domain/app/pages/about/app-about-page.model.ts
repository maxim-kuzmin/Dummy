import { inject } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppAboutPageResourcesService } from './resources/app-about-page-resources.service';
import { AppAboutPageService } from './app-about-page.service';

export class AppAboutPageModel {
  private readonly appAboutPageResourcesService = inject(
    AppAboutPageResourcesService
  );

  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(): void {
    this.pageStoreService.pageKey.set(this.appAboutPageService.createPageKey());

    this.pageStoreService.pageTitle.set(
      this.appAboutPageResourcesService.getTitle()
    );
  }
}
