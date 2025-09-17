import { inject } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';
import { AppAboutPageService } from './app-about-page.service';

export class AppAboutPageModel {
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly pageService = inject(PageService);

  load(): void {
    this.pageService.key.set(this.appAboutPageService.createPageKey());
    this.pageService.title.set($localize`:@@page.about.title:@@`);
  }
}
