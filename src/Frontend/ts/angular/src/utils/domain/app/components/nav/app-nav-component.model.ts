import { inject, signal } from '@angular/core';
import { UrlTree } from '@angular/router';
import { PageStoreService } from '~/utils/infrastructure/page/store/page-store.service';
import { PageUrlService } from '~/utils/infrastructure/page/url/page-url.service';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { AppAboutPageService } from '~/utils/domain/app/pages/about/app-about-page.service';
import { AppFakePageService } from '~/utils/domain/app/pages/fake/app-fake-page.service';
import { AppFakePageDataQuery } from '~/utils/domain/app/pages/fake/app-fake-page.types';
import { AppNavComponentItem } from './app-nav-component.types';

export class AppNavComponentModel {
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly appFakePageService = inject(AppFakePageService);
  private readonly languageService = inject(LanguageService);
  private readonly pageStoreService = inject(PageStoreService);
  private readonly pageUrlService = inject(PageUrlService);

  readonly items = signal<AppNavComponentItem[]>([]);

  load(): void {
    this.items.set(this.createFakeItems());
  }

  private createFakeItems(): AppNavComponentItem[] {
    const locale = this.languageService.getCurrentLanguage().code;

    return [
      this.createItemForAboutPage(),
      this.createItemForFakePageByDataQuery({ id: '1', locale, pageNumber: 1 }),
      this.createItemForFakePageByDataQuery({ id: '1', locale, pageNumber: 2 }),
      this.createItemForFakePageByDataQuery({ id: '2', locale, pageNumber: 1 }),
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
    const text = $localize`:@@app.pages.app-about-page.title:@@`;

    const key = this.appAboutPageService.createPageKey();

    const urlTree = this.pageUrlService.createUrlTree(
      this.appAboutPageService.createPageUrlOptions()
    );

    return this.createItem(key, urlTree, text);
  }

  private createItemForFakePage(
    text: string,
    children: AppNavComponentItem[] = []
  ): AppNavComponentItem {
    const locale = this.languageService.getCurrentLanguage().code;

    const dataQuery = {
      id: text,
      locale,
      pageNumber: 1,
    } as AppFakePageDataQuery;

    const key = this.appFakePageService.createPageKey(dataQuery);

    const urlTree = this.pageUrlService.createUrlTree(
      this.appFakePageService.createPageUrlOptions(dataQuery)
    );

    return this.createItem(key, urlTree, text, children);
  }

  private createItemForFakePageByDataQuery(
    dataQuery: AppFakePageDataQuery,
    children: AppNavComponentItem[] = []
  ): AppNavComponentItem {
    const key = this.appFakePageService.createPageKey(dataQuery);
    const urlTree = this.pageUrlService.createUrlTree(
      this.appFakePageService.createPageUrlOptions(dataQuery)
    );

    return this.createItem(key, urlTree, key, children);
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
