import { inject } from '@angular/core';
import { AppNavIndexComponentStoreService } from './store/app-nav-index-component-store.service';

export class AppNavIndexComponentModel {
  private readonly appNavIndexComponentStoreService = inject(
    AppNavIndexComponentStoreService
  );

  load(): void {
    this.appNavIndexComponentStoreService.load()
  }
}
