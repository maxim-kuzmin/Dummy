import { Component, effect, inject } from '@angular/core';
import { AppIndexService } from '../app-index.service';

@Component({
  selector: 'div[app-index-page]',
  templateUrl: './app-index-page.component.html',
})
export class AppIndexPage {
  private service = inject(AppIndexService);

  constructor() {
    effect(() => {
      this.service.loadPageData();
    });
  }
}
