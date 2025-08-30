import { Component, inject } from '@angular/core';
import { PageService } from '~shared/page/page.service';
import { PageKeyEnum } from '~shared/page/page.types';

@Component({
  selector: 'div[app-index-page]',
  templateUrl: './app-index-page.component.html',
})
export class AppIndexPage {
  private pageService = inject(PageService);

  constructor() {
    this.pageService.title.set($localize`:@@page.index.title:@@`);
    this.pageService.key.set(PageKeyEnum.Index);
  }
}
