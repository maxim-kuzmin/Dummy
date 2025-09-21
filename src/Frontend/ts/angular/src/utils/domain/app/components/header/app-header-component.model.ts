import { inject } from '@angular/core';
import { UrlTree } from '@angular/router';
import { AppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service';
import { UrlService } from '~/utils/infrastructure/url/url.service';
import { AppHeaderComponentResourcesService } from './resources/app-header-component-resources.service';

export class AppHeaderComponentModel {
  private readonly appHeaderComponentResourcesService = inject(
    AppHeaderComponentResourcesService
  );

  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly urlService = inject(UrlService);

  indexPageName = '';
  indexPageUrlTree = new UrlTree();

  load() {
    this.indexPageName = this.appHeaderComponentResourcesService.getTitle();

    this.indexPageUrlTree = this.urlService.createUrlTree(
      this.appIndexPageService.createPageUrlOptions()
    );
  }
}
