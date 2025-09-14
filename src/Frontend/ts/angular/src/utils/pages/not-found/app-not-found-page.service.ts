import { inject, Injectable } from '@angular/core';
import { PageService } from '#utils/shared/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppNotFoundPageService {
  private readonly pageService = inject(PageService);

  createPageKey(): string {
    return 'NotFound';
  }

  loadPageData() {
    this.pageService.key.set(this.createPageKey());

    this.pageService.title.set($localize`:@@page.not-found.title:@@`);
  }
}
