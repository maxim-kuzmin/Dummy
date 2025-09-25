import { Component, effect, inject } from '@angular/core';
import { AppAboutPageModel } from '~/utils/domain/app/pages/about/app-about-page.model';

@Component({
  selector: 'div[app-about-page]',
  templateUrl: './app-about-page.component.html',
  providers: [AppAboutPageModel],
})
export class AppAboutPage {
  private readonly appAboutPageModel = inject(AppAboutPageModel, {
    self: true,
  });

  constructor() {
    effect(() => {
      this.appAboutPageModel.load();
    });
  }
}
