import { inject, signal } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';

export class AppMainComponentModel {
  private readonly pageStoreService = inject(PageStoreService);

  readonly title = signal('');

  load() {
    this.title.set(this.pageStoreService.pageTitle());
  }
}
