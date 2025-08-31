import { Component, effect, inject } from '@angular/core';
import { AppNotFoundService } from '../app-not-found.service';

@Component({
  selector: 'div[app-not-found-page]',
  templateUrl: './app-not-found-page.component.html',
})
export class AppNotFoundPage {
  private service = inject(AppNotFoundService);

  constructor() {
    effect(() => {
      this.service.loadPageData();
    });
  }
}
