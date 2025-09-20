import { Component, effect, inject } from '@angular/core';
import { AppFakePageModel } from '~/utils/domain/app/pages/fake/app-fake-page.model';

@Component({
  selector: 'div[app-fake-page]',
  templateUrl: './app-fake-page.component.html',
  providers: [AppFakePageModel],
})
export class AppFakePage {
  private model = inject(AppFakePageModel, { self: true });

  protected get clickCount(): number {
    return this.model.clickCount();
  }

  protected get pageKey(): string {
    return this.model.pageKey();
  }

  protected click(): void {
    this.model.click();
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
