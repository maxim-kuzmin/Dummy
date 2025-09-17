import { inject, signal } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';

export class AppMainComponentModel {
  private readonly pageService = inject(PageService);

  readonly title = signal('');

  load() {
    this.title.set(this.pageService.title());
  }
}
