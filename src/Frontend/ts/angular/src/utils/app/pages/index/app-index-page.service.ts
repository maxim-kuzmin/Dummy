import { inject, Injectable } from '@angular/core';
import { paths } from '~/utils/app/app.types';
import { PageService } from '~/utils/shared/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppIndexPageService {
  private readonly pageService = inject(PageService);

  createPageKey(): string {
    return 'Index';
  }

  createPageUrl(): string {
    return `/${paths.index}`;
  }

  loadPageData(): void {
    this.pageService.key.set(this.createPageKey());

    this.pageService.title.set($localize`:@@page.index.title:@@`);
  }
}
