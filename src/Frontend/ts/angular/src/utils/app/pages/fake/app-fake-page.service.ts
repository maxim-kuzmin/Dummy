import { computed, inject, Injectable } from '@angular/core';
import { fakePagePath } from '~/app/app.paths';
import { PageService } from '~/utils/shared/page/page.service';
import { AppFakePageData, AppFakePageRouteParams } from './app-fake-page.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageService {
  private readonly pageService = inject(PageService);

  readonly pageData: AppFakePageData = {
    key: computed(() => this.pageService.key()),
  };

  createPageKey(params: AppFakePageRouteParams): string {
    return `Fake:${params.id}`;
  }

  createPageUrl(params: AppFakePageRouteParams): string {
    return `/${fakePagePath.replace(':id', params.id)}`;
  }

  loadPageData(id: string): void {
    this.pageService.key.set(this.createPageKey({ id }));

    this.pageService.title.set(`${$localize`:@@page.fake.title:@@`} ${id}`);
  }
}
