import { Component, inject } from '@angular/core';
import { PageService } from '~shared/page/page.service';
import { PageKeyEnum } from '~shared/page/page.types';

@Component({
  selector: 'div[app-about-page]',
  templateUrl: './app-about-page.component.html',
})
export class AppAboutPage {
  private pageService = inject(PageService);

  constructor() {
    this.pageService.title.set($localize`:@@page.about.title:@@`);
    this.pageService.key.set(PageKeyEnum.About);
  }
}
