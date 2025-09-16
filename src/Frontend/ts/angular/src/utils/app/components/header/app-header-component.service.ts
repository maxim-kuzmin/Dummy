import { inject, Injectable } from '@angular/core';
import { AppIndexPageService } from '~/utils/app/pages/index/app-index-page.service';
import { AppHeaderComponentData } from './app-header-component.types';

@Injectable({
  providedIn: 'root',
})
export class AppHeaderComponentService {
  private readonly appIndexPageService = inject(AppIndexPageService);

  private readonly data = new AppHeaderComponentData();

  get indexPageName() {
    return this.data.indexPageName;
  }

  get indexPageUrl() {
    return this.data.indexPageUrl;
  }

  load() {
    this.data.indexPageName = $localize`:@@component.app-header.link.index.text:@@`;
    this.data.indexPageUrl = this.appIndexPageService.createPageUrl();
  }
}
