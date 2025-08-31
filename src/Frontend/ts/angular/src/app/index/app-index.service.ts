import { inject, Injectable } from '@angular/core';
import { PageService } from '~shared/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppIndexService {
  private readonly pageService = inject(PageService);

  createPageKey(): string {
    return 'Index';
  }

  createPageUrl(): string {
    return '/index';
  }

  loadPageData() {
    this.pageService.key.set(this.createPageKey());

    this.pageService.title.set($localize`:@@page.index.title:@@`);
  }
}
