import { inject, Injectable } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';
import { AppMainComponentData } from './app-main-component.types';

@Injectable({
  providedIn: 'root',
})
export class AppMainComponentService {
  private readonly pageService = inject(PageService);

  private readonly data = new AppMainComponentData();

  get title() {
    return this.data.title;
  }

  load() {
    this.data.title.set(this.pageService.title())
  }
}
