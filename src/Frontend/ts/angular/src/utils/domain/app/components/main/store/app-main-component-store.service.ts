import { inject, Injectable, Signal, signal } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';

@Injectable({
  providedIn: 'root',
})
export class AppMainComponentStoreService {
  private readonly pageStoreService = inject(PageStoreService);

  private readonly _title = signal('');

  get title(): Signal<string> {
    return this._title;
  }

  load() {
    this._title.set(this.pageStoreService.pageTitle());
  }
}
