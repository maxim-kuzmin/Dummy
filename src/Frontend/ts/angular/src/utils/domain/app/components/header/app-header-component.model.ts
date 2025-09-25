import { inject } from '@angular/core';
import { AppHeaderComponentStoreService } from './store/app-header-component-store.service';

export class AppHeaderComponentModel {
  private readonly appHeaderComponentStoreService = inject(
    AppHeaderComponentStoreService
  );

  load(): void {
    this.appHeaderComponentStoreService.load();
  }
}
