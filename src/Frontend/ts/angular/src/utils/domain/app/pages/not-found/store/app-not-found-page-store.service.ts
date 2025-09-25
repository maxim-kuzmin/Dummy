import { inject, Injectable, Signal, signal } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppNotFoundPageApiDataOptions } from '../api/app-not-found-page-api.types';
import { AppNotFoundPageResourcesService } from '../resources/app-not-found-page-resources.service';
import { AppNotFoundPageService } from '../app-not-found-page.service';

@Injectable({
  providedIn: 'root',
})
export class AppNotFoundPageStoreService {
  private readonly appNotFoundPageResourcesService = inject(
    AppNotFoundPageResourcesService
  );
  private readonly appNotFoundPageService = inject(AppNotFoundPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(dataOptions: AppNotFoundPageApiDataOptions): void {
    this.pageStoreService.load({
      pageKey: this.appNotFoundPageService.createPageKey(dataOptions.locale),
      pageTitle: this.appNotFoundPageResourcesService.getTitle(),
    });
  }
}
