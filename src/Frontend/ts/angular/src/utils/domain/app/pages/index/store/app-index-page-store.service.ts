import { inject, Injectable, Signal, signal } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppIndexPageApiDataOptions } from '../api/app-index-page-api.types';
import { AppIndexPageResourcesService } from '../resources/app-index-page-resources.service';
import { AppIndexPageService } from '../app-index-page.service';

@Injectable({
  providedIn: 'root',
})
export class AppIndexPageStoreService {
  private readonly appIndexPageResourcesService = inject(
    AppIndexPageResourcesService
  );
  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(dataOptions: AppIndexPageApiDataOptions): void {
    this.pageStoreService.load({
      pageKey: this.appIndexPageService.createPageKey(dataOptions.locale),
      pageTitle: this.appIndexPageResourcesService.getTitle(),
    });
  }
}
