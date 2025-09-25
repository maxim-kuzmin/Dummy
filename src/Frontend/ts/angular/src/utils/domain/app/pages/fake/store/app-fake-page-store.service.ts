import { inject, Injectable, Signal, signal } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppFakePageResourcesService } from '../resources/app-fake-page-resources.service';
import { AppFakePageService } from '../app-fake-page.service';
import {
  AppFakePageApiDataOptions,
  AppFakePageApiDataQuery,
} from '../api/app-fake-page-api.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageStoreService {
  private readonly appFakePageResourcesService = inject(
    AppFakePageResourcesService
  );
  private readonly appFakePageService = inject(AppFakePageService);
  private readonly pageStoreService = inject(PageStoreService);

  private readonly _clickCount = signal(0);
  private readonly _pageKey = signal('');

  get clickCount(): Signal<number> {
    return this._clickCount;
  }

  get pageKey(): Signal<string> {
    return this._pageKey;
  }

  incrementClickCount() {
    this._clickCount.set(this._clickCount() + 1);
  }

  load(
    dataQuery: AppFakePageApiDataQuery,
    dataOptions: AppFakePageApiDataOptions
  ): void {
    const pageTitle = this.appFakePageResourcesService.getTitle(
      dataQuery.id,
      dataQuery.pageNumber
    );

    this.pageStoreService.load({
      pageKey: this.appFakePageService.createPageKey(
        dataQuery,
        dataOptions.locale
      ),
      pageTitle,
    });

    this._pageKey.set(this.pageStoreService.pageKey());
  }
}
