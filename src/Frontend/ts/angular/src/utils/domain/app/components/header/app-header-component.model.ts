import { inject } from '@angular/core';
import { UrlTree } from '@angular/router';
import { AppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service';
import { PageUrlService } from '~/utils/infrastructure/page/url/page-url.service';
import { AppHeaderComponentResourcesService } from './resources/app-header-component-resources.service';

export class AppHeaderComponentModel {
  private readonly appHeaderComponentResourcesService = inject(
    AppHeaderComponentResourcesService
  );

  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageUrlService = inject(PageUrlService);

  indexPageName = '';
  indexPageUrlTree = new UrlTree();

  load() {
    this.indexPageName = this.appHeaderComponentResourcesService.getTitle();

    this.indexPageUrlTree = this.pageUrlService.createPageUrlTree(
      this.appIndexPageService.createPageUrlOptions()
    );
  }
}
