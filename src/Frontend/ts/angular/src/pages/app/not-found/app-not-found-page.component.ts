import { Component, effect, inject } from '@angular/core';
import { AppNotFoundPageModel } from '~/utils/domain/app/pages/not-found/app-not-found-page.model';

@Component({
  selector: 'div[app-not-found-page]',
  templateUrl: './app-not-found-page.component.html',
  providers: [AppNotFoundPageModel],
})
export class AppNotFoundPage {
  private model = inject(AppNotFoundPageModel, { self: true });

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
