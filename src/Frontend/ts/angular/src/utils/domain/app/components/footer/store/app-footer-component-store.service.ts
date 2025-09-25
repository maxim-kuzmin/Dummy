import { inject, Injectable, Signal, signal } from '@angular/core';
import { AppFooterComponentResourcesService } from '../resources/app-footer-component-resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppFooterComponentStoreService {
  private readonly appFooterComponentResourcesService = inject(
    AppFooterComponentResourcesService
  );

  private readonly _title = signal('');

  get title(): Signal<string> {
    return this._title;
  }

  load() {
    this._title.set(this.appFooterComponentResourcesService.getTitle());
  }
}
