import { inject, Injectable } from '@angular/core';
import { PageService } from '#utils/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageService {
  private readonly pageService = inject(PageService);

  createPageKey(): string {
    return 'About';
  }

  createPageUrl(): string {
    return '/about';
  }

  loadPageData() {
    this.pageService.key.set(this.createPageKey());

    this.pageService.title.set($localize`:@@page.about.title:@@`);
  }
}
