import { inject } from '@angular/core';
import { AppFooterComponentStoreService } from './store/app-footer-component-store.service';

export class AppFooterComponentModel {
  private readonly appFooterComponentStoreService = inject(
    AppFooterComponentStoreService
  );

  load(): void {
    this.appFooterComponentStoreService.load();
  }
}
