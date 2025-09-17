import { Component, effect, inject } from '@angular/core';
import { AppIndexPageModel } from '~/utils/app/pages/index/app-index-page.model';

@Component({
  selector: 'div[app-index-page]',
  templateUrl: './app-index-page.component.html',
  providers: [AppIndexPageModel],
})
export class AppIndexPage {
  private model = inject(AppIndexPageModel, { self: true });

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
