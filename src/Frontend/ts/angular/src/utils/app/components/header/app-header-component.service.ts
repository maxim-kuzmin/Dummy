import { inject, Injectable } from '@angular/core';
import { AppIndexPageService } from '~/utils/app/pages/index/app-index-page.service';

@Injectable({
  providedIn: 'root',
})
export class AppHeaderComponentService {
  private readonly appIndexPageService = inject(AppIndexPageService);

  indexPageName = ''
  indexPageUrl = ''

  load() {
    this.indexPageName = $localize`:@@component.app-header.link.index.text:@@`;
    this.indexPageUrl = this.appIndexPageService.createPageUrl();
  }
}
