import { inject, Injectable } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';
import { AppMainComponentData } from './app-main-component.types';

@Injectable({
  providedIn: 'root',
})
export class AppMainComponentService {
  private readonly pageService = inject(PageService);

  readonly componentData = {
    title: this.pageService.title,
  } as AppMainComponentData;
}
