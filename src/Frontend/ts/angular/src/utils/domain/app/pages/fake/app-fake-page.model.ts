import { inject, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { AppFakePageResourcesService } from './resources/app-fake-page-resources.service';
import { AppFakePageService } from './app-fake-page.service';
import { appFakePageParameters } from './app-fake-page.types';

export class AppFakePageModel {
  private readonly appFakePageService = inject(AppFakePageService);
  private readonly appFakePageResourcesService = inject(AppFakePageResourcesService)
  private readonly pageStoreService = inject(PageStoreService);

  private readonly activatedRoute = inject(ActivatedRoute);

  private readonly routeParams = toSignal(this.activatedRoute.params, {
    requireSync: true,
  });

  private readonly queryParams = toSignal(this.activatedRoute.queryParams, {
    requireSync: true,
  });

  readonly clickCount = signal(0)
  readonly pageKey = signal('');

  click() {
    this.clickCount.set(this.clickCount() + 1)
  }

  load(): void {
    const id = String(this.routeParams()[appFakePageParameters.id.name]);

    const pageNumber = Number(
      this.queryParams()[appFakePageParameters.pageNumber.name] ??
        appFakePageParameters.pageNumber.defaultValue
    );

    const pageKey = this.appFakePageService.createPageKey({ id, pageNumber });

    this.pageStoreService.pageKey.set(pageKey);
    this.pageStoreService.pageTitle.set(this.appFakePageResourcesService.getTitle(id));

    this.pageKey.set(pageKey);
  }
}
