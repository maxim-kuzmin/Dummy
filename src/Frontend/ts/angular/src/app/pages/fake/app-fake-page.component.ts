import { Component, effect, inject } from '@angular/core';
import { AppFakePageModel } from '~/utils/app/pages/fake/app-fake-page.model';

@Component({
  selector: 'div[app-fake-page]',
  templateUrl: './app-fake-page.component.html',
  providers: [AppFakePageModel],
})
export class AppFakePage {
  private model = inject(AppFakePageModel);

  protected get key() {
    return this.model.key()
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
