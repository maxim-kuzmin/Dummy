import { inject, Injectable, Signal, signal } from '@angular/core';
import { UrlTree } from '@angular/router';
import { AppAboutPageResourcesService } from '~/utils/domain/app/pages/about/resources/app-about-page-resources.service';
import { AppAboutPageService } from '~/utils/domain/app/pages/about/app-about-page.service';
import { AppFakePageApiDataQuery } from '~/utils/domain/app/pages/fake/api/app-fake-page-api.types';
import { AppFakePageResourcesService } from '~/utils/domain/app/pages/fake/resources/app-fake-page-resources.service';
import { AppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { PageUrlService } from '~/utils/infrastructure/page/url/page-url.service';
import { AppNavComponentItem } from '../../app-nav-component.types';

@Injectable({
  providedIn: 'root',
})
export class AppNavIndexComponentStoreService {
  private readonly appAboutPageResourcesService = inject(
    AppAboutPageResourcesService
  );
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly appFakePageResourcesService = inject(
    AppFakePageResourcesService
  );
  private readonly appFakePageService = inject(AppFakePageService);
  private readonly languageService = inject(LanguageService);
  private readonly pageStoreService = inject(PageStoreService);
  private readonly pageUrlService = inject(PageUrlService);

  private readonly _items = signal<AppNavComponentItem[]>([]);

  get items(): Signal<AppNavComponentItem[]> {
    return this._items;
  }

  load(): void {
    this._items.set(this.createFakeItems());
  }

  private createFakeItems(): AppNavComponentItem[] {
    return [
      this.createItemForAboutPage(),
      this.createItemForFakePageByDataQuery({ id: '1', pageNumber: 1 }),
      this.createItemForFakePageByDataQuery({ id: '1', pageNumber: 2 }),
      this.createItemForFakePageByDataQuery({ id: '2', pageNumber: 1 }),
      this.createItemForFakePage('11111', [
        this.createItemForFakePage('11111-1'),
        this.createItemForFakePage('11111-2'),
        this.createItemForFakePage('11111-3', [
          this.createItemForFakePage('11111-3-1'),
          this.createItemForFakePage('11111-3-2'),
          this.createItemForFakePage('11111-3-3', [
            this.createItemForFakePage('11111-3-3-1'),
            this.createItemForFakePage('11111-3-3-2'),
            this.createItemForFakePage('11111-3-3-3'),
            this.createItemForFakePage('11111-3-3-4'),
            this.createItemForFakePage('11111-3-3-5'),
          ]),
          this.createItemForFakePage('11111-3-4'),
          this.createItemForFakePage('11111-3-5'),
        ]),
        this.createItemForFakePage('11111-4'),
        this.createItemForFakePage('11111-5'),
      ]),
      this.createItemForFakePage('22222'),
      this.createItemForFakePage('33333'),
      this.createItemForFakePage('44444'),
      this.createItemForFakePage('55555'),
    ];
  }

  private createItemForAboutPage(): AppNavComponentItem {
    const text = this.appAboutPageResourcesService.getTitle();

    const languageCode = this.languageService.getCurrentLanguage().code;

    const key = this.appAboutPageService.createPageKey(languageCode);

    const urlTree = this.pageUrlService.createUrlTree(
      this.appAboutPageService.createPageUrlOptions()
    );

    return this.createItem(key, urlTree, text);
  }

  private createItemForFakePage(
    id: string,
    children: AppNavComponentItem[] = []
  ): AppNavComponentItem {
    const text = this.appFakePageResourcesService.getTitle(id, 1);

    const languageCode = this.languageService.getCurrentLanguage().code;

    const dataQuery = { id: id, pageNumber: 1 } as AppFakePageApiDataQuery;

    const key = this.appFakePageService.createPageKey(dataQuery, languageCode);

    const urlTree = this.pageUrlService.createUrlTree(
      this.appFakePageService.createPageUrlOptions(dataQuery)
    );

    return this.createItem(key, urlTree, text, children);
  }

  private createItemForFakePageByDataQuery(
    dataQuery: AppFakePageApiDataQuery,
    children: AppNavComponentItem[] = []
  ): AppNavComponentItem {
    const text = this.appFakePageResourcesService.getTitle(
      dataQuery.id,
      dataQuery.pageNumber
    );

    const languageCode = this.languageService.getCurrentLanguage().code;

    const key = this.appFakePageService.createPageKey(dataQuery, languageCode);

    const urlTree = this.pageUrlService.createUrlTree(
      this.appFakePageService.createPageUrlOptions(dataQuery)
    );

    return this.createItem(key, urlTree, text, children);
  }

  private createItem(
    key: string,
    urlTree: UrlTree,
    text: string,
    children: AppNavComponentItem[] = []
  ): AppNavComponentItem {
    const selected = this.pageStoreService.pageKey() === key;

    return {
      key,
      text,
      urlTree,
      children,
      selected,
    } as AppNavComponentItem;
  }
}
