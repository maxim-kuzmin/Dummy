import { inject } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';
import { AppNotFoundPageService } from './app-not-found-page.service';

export class AppNotFoundPageModel {
  private readonly appNotFoundPageService = inject(AppNotFoundPageService);
  private readonly pageService = inject(PageService);

  load(): void {
    this.pageService.key.set(this.appNotFoundPageService.createPageKey());
    this.pageService.title.set($localize`:@@page.not-found.title:@@`);
  }
}
