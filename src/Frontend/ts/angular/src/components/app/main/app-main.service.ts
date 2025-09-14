import { inject, Injectable } from '@angular/core';
import { ComponentData } from './app-main.types';
import { PageService } from '~/utils/shared/page/page.service';

@Injectable({
  providedIn: 'root',
})
export class AppMainService {
  private readonly pageService = inject(PageService);

  readonly componentData = {
    title: this.pageService.title,
  } as ComponentData;
}
