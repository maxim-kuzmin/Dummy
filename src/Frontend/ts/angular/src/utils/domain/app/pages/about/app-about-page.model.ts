import { inject } from '@angular/core';
import { PageService } from '~/utils/infrastructure/page/page.service';
import { AppAboutPageResourcesService } from './resources/app-about-page-resources.service';
import { AppAboutPageService } from './app-about-page.service';

export class AppAboutPageModel {
  private readonly appAboutPageResourcesService = inject(
    AppAboutPageResourcesService
  );

  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly pageService = inject(PageService);

  load(): void {
    this.pageService.pageKey.set(this.appAboutPageService.createPageKey());

    this.pageService.pageTitle.set(
      this.appAboutPageResourcesService.getTitle()
    );
  }
}
