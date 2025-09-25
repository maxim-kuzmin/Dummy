import { inject, Injectable, Signal, signal } from '@angular/core';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppAboutPageApiDataOptions } from '../api/app-about-page-api.types';
import { AppAboutPageResourcesService } from '../resources/app-about-page-resources.service';
import { AppAboutPageService } from '../app-about-page.service';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageStoreService {
  private readonly appAboutPageResourcesService = inject(
    AppAboutPageResourcesService
  );
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly pageStoreService = inject(PageStoreService);

  load(dataOptions: AppAboutPageApiDataOptions): void {
    this.pageStoreService.load({
      pageKey: this.appAboutPageService.createPageKey(dataOptions.locale),
      pageTitle: this.appAboutPageResourcesService.getTitle(),
    });
  }
}
