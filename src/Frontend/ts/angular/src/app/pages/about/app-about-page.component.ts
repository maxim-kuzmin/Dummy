import { Component, effect, inject } from '@angular/core';
import { AppAboutPageService } from '~/utils/app/pages/about/app-about-page.service';

@Component({
  selector: 'div[app-about-page]',
  templateUrl: './app-about-page.component.html',
})
export class AppAboutPage {
  private service = inject(AppAboutPageService);

  constructor() {
    effect(() => {
      this.service.load();
    });
  }
}
