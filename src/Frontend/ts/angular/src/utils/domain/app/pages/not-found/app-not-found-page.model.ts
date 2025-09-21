import { inject } from '@angular/core';
import { PageService } from '~/utils/infrastructure/page/page.service';
import { AppNotFoundPageResourcesService } from './resources/app-not-found-page-resources.service';
import { AppNotFoundPageService } from './app-not-found-page.service';

export class AppNotFoundPageModel {
  private readonly appNotFoundPageResourcesService = inject(
    AppNotFoundPageResourcesService
  );

  private readonly appNotFoundPageService = inject(AppNotFoundPageService);
  private readonly pageService = inject(PageService);

  load(): void {
    this.pageService.pageKey.set(this.appNotFoundPageService.createPageKey());

    this.pageService.pageTitle.set(this.appNotFoundPageResourcesService.getTitle());
  }
}
