import { inject, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';
import { PageService } from '~/utils/infrastructure/page/page.service';
import { AppFakePageResourcesService } from './resources/app-fake-page-resources.service';
import { AppFakePageService } from './app-fake-page.service';
import { appFakePageParameters } from './app-fake-page.types';

export class AppFakePageModel {
  private readonly appFakePageResourcesService = inject(AppFakePageResourcesService)
  private readonly appFakePageService = inject(AppFakePageService);
  private readonly pageService = inject(PageService);

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

    this.pageService.pageKey.set(this.appFakePageService.createPageKey({ id, pageNumber }));

    this.pageService.pageTitle.set(this.appFakePageResourcesService.getTitle(id));

    this.pageKey.set(this.pageService.pageKey());
  }
}
