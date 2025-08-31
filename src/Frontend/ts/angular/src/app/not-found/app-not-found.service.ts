import { inject, Injectable } from '@angular/core';
import { PageService } from '~shared/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppNotFoundService {
  private readonly pageService = inject(PageService);

  createPageKey(): string {
    return 'NotFound';
  }

  loadPageData() {
    this.pageService.key.set(this.createPageKey());

    this.pageService.title.set($localize`:@@page.not-found.title:@@`);
  }
}
