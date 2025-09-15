import { Component, effect, inject } from '@angular/core';
import { AppNotFoundPageService } from '~/utils/app/pages/not-found/app-not-found-page.service';

@Component({
  selector: 'div[app-not-found-page]',
  templateUrl: './app-not-found-page.component.html',
})
export class AppNotFoundPage {
  private service = inject(AppNotFoundPageService);

  constructor() {
    effect(() => {
      this.service.loadPageData();
    });
  }
}
