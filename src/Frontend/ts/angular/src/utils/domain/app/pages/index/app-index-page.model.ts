import { inject } from '@angular/core';
import { PageService } from '~/utils/infrastructure/page/page.service';
import { AppIndexPageService } from './app-index-page.service';

export class AppIndexPageModel {
  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageService = inject(PageService);

  load(): void {
    this.pageService.key.set(this.appIndexPageService.createPageKey());
    this.pageService.title.set($localize`:@@app.pages.app-index-page.title:@@`);
  }
}
