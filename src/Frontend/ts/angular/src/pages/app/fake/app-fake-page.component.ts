import { Component, effect, inject } from '@angular/core';
import { AppFakePageModel } from '~/utils/domain/app/pages/fake/app-fake-page.model';

@Component({
  templateUrl: './app-fake-page.component.html',
  providers: [AppFakePageModel],
})
export class AppFakePage {
  private model = inject(AppFakePageModel, { self: true });

  protected get key() {
    return this.model.key();
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
