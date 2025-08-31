import { Component, effect, inject } from '@angular/core';
import { AppAboutService } from '../app-about.service';

@Component({
  selector: 'div[app-about-page]',
  templateUrl: './app-about-page.component.html',
})
export class AppAboutPage {
  private service = inject(AppAboutService);

  constructor() {
    effect(() => {
      this.service.loadPageData();
    });
  }
}
