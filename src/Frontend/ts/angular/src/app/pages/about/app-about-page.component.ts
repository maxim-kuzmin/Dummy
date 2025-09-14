import { Component, effect, inject } from '@angular/core';
import { AppAboutPageService } from './app-about-page.service';

@Component({
  selector: 'div[app-about-page]',
  templateUrl: './app-about-page.component.html',
})
export class AppAboutPage {
  private service = inject(AppAboutPageService);

  constructor() {
    effect(() => {
      this.service.loadPageData();
    });
  }
}
