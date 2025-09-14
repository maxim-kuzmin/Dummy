import { computed, inject, Injectable } from '@angular/core';
import { fakePagePath } from '#app/app.paths';
import { PageService } from '#utils/page/page.service';
import { PageData } from './app-fake-page.types';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageService {
  private readonly pageService = inject(PageService);

  readonly pageData: PageData = {
    key: computed(() => this.pageService.key()),
  };

  createPageKey(id: string): string {
    return `Fake:${id}`;
  }

  createPageUrl(id: string): string {
    return `/${fakePagePath.replace(':id', id)}`;
  }

  loadPageData(id: string): void {
    this.pageService.key.set(this.createPageKey(id));

    this.pageService.title.set(`${$localize`:@@page.fake.title:@@`} ${id}`);
  }
}
