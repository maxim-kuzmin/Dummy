import { Component, effect, inject } from '@angular/core';
import { AppFakePageStoreService } from '~/utils/domain/app/pages/fake/store/app-fake-page-store.service';
import { AppFakePageModel } from '~/utils/domain/app/pages/fake/app-fake-page.model';

@Component({
  selector: 'div[app-fake-page]',
  templateUrl: './app-fake-page.component.html',
  providers: [AppFakePageModel],
})
export class AppFakePage {
  private readonly appFakePageModel = inject(AppFakePageModel, { self: true });
  private readonly appFakePageStoreService = inject(AppFakePageStoreService);

  protected get clickCount(): number {
    return this.appFakePageStoreService.clickCount();
  }

  protected get pageKey(): string {
    return this.appFakePageStoreService.pageKey();
  }

  protected click(): void {
    this.appFakePageStoreService.incrementClickCount();
  }

  constructor() {
    effect(() => {
      this.appFakePageModel.load();
    });
  }
}
