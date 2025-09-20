import { inject } from '@angular/core';
import { AppFooterComponentResourcesService } from './resources/app-footer-component-resources.service';

export class AppFooterComponentModel {
  private readonly appFooterComponentResourcesService = inject(
    AppFooterComponentResourcesService
  );

  title = '';

  load() {
    this.title = this.appFooterComponentResourcesService.getTitle();
  }
}
