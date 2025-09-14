import { Component, effect, inject } from '@angular/core';
import { AppIndexPageService } from '~/utils/pages/index/app-index-page.service';

@Component({
  selector: 'div[app-index-page]',
  templateUrl: './app-index-page.component.html',
})
export class AppIndexPage {
  private service = inject(AppIndexPageService);

  constructor() {
    effect(() => {
      this.service.loadPageData();
    });
  }
}
