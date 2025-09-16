import { inject, Injectable, signal } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppMainComponentService {
  private readonly pageService = inject(PageService);

  readonly title = signal('');

  load() {
    this.title.set(this.pageService.title());
  }
}
