import { inject } from '@angular/core';
import { AppMainComponentStoreService } from './store/app-main-component-store.service';

export class AppMainComponentModel {
  private readonly appMainComponentStoreService = inject(
    AppMainComponentStoreService
  );

  load() {
    this.appMainComponentStoreService.load();
  }
}
