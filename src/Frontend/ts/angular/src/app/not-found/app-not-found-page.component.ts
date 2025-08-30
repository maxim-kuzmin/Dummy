import { Component, inject } from '@angular/core';
import { PageService } from '~shared/page/page.service';
import { PageKeyEnum } from '~shared/page/page.types';

@Component({
  selector: 'div[app-not-found-page]',
  templateUrl: './app-not-found-page.component.html',
})
export class AppNotFoundPage {
  private pageService = inject(PageService);

  constructor() {
    this.pageService.title.set($localize`:@@page.not-found.title:@@`);
    this.pageService.key.set(PageKeyEnum.NotFound);
  }
}
