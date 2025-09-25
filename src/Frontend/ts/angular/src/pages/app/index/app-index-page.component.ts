import { Component, effect, inject } from '@angular/core';
import { AppIndexPageModel } from '~/utils/domain/app/pages/index/app-index-page.model';

@Component({
  selector: 'div[app-index-page]',
  templateUrl: './app-index-page.component.html',
  providers: [AppIndexPageModel],
})
export class AppIndexPage {
  private readonly appIndexPageModel = inject(AppIndexPageModel, {
    self: true,
  });

  constructor() {
    effect(() => {
      this.appIndexPageModel.load();
    });
  }
}
