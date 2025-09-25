import { inject, Injectable, Signal, signal } from '@angular/core';
import { UrlTree } from '@angular/router';
import { AppIndexPageService } from '~/utils/domain/app/pages/index/app-index-page.service';
import { PageUrlService } from '~/utils/infrastructure/page/url/page-url.service';
import { AppHeaderComponentResourcesService } from '../resources/app-header-component-resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppHeaderComponentStoreService {
  private readonly appHeaderComponentResourcesService = inject(
    AppHeaderComponentResourcesService
  );
  private readonly appIndexPageService = inject(AppIndexPageService);
  private readonly pageUrlService = inject(PageUrlService);

  private readonly _indexPageName = signal('');
  private readonly _indexPageUrlTree = signal(new UrlTree());

  get indexPageName(): Signal<string> {
    return this._indexPageName;
  }

  get indexPageUrlTree(): Signal<UrlTree> {
    return this._indexPageUrlTree;
  }

  load() {
    this._indexPageName.set(this.appHeaderComponentResourcesService.getTitle());

    this._indexPageUrlTree.set(
      this.pageUrlService.createUrlTree(
        this.appIndexPageService.createPageUrlOptions()
      )
    );
  }
}
