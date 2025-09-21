import { inject } from '@angular/core';
import { PageService } from '~/utils/infrastructure/page/page.service';
import { AppIndexPageResourcesService } from './resources/app-index-page-resources.service';
import { AppIndexPageService } from './app-index-page.service';

export class AppIndexPageModel {
  private readonly appIndexPageResourcesService = inject(
    AppIndexPageResourcesService
  );

  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageService = inject(PageService);

  load(): void {
    this.pageService.pageKey.set(this.appIndexPageService.createPageKey());

    this.pageService.pageTitle.set(
      this.appIndexPageResourcesService.getTitle()
    );
  }
}
