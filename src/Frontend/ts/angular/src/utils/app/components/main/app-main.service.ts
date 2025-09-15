import { inject, Injectable } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';
import { ComponentData } from './app-main.types';

@Injectable({
  providedIn: 'root',
})
export class AppMainService {
  private readonly pageService = inject(PageService);

  readonly componentData = {
    title: this.pageService.title,
  } as ComponentData;
}
