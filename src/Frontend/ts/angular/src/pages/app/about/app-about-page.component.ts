import { Component, effect, inject } from '@angular/core';
import { AppAboutPageModel } from '~/utils/domain/app/pages/about/app-about-page.model';

@Component({
  templateUrl: './app-about-page.component.html',
  providers: [AppAboutPageModel],
})
export class AppAboutPage {
  private model = inject(AppAboutPageModel, { self: true });

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
