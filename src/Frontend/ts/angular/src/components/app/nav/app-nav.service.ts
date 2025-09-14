import { inject, Injectable, signal } from '@angular/core';
import { ComponentData, Item } from './app-nav.types';
import { PageService } from '#utils/shared/page/page.service';
import { AppAboutPageService } from '#utils/pages/about/app-about-page.service';
import { AppFakePageService } from '#utils/pages/fake/app-fake-page.service';

@Injectable({
  providedIn: 'root',
})
export class AppNavService {
  private readonly pageService = inject(PageService);
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly appFakePageService = inject(AppFakePageService);

  readonly componentData = {
    items: signal([]),
  } as ComponentData;

  loadComponentData() {
    this.componentData.items.set(this.createFakeItems());
  }

  private createFakeItems(): Item[] {
    return [
        this.createItemForAboutPage(),
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

  private createItemForAboutPage(): Item {
    const text = $localize`:@@page.about.title:@@`;
    const key = this.appAboutPageService.createPageKey();
    const url = this.appAboutPageService.createPageUrl();

    return this.createItem(key, url, text);
  }

  private createItemForFakePage(text: string, children: Item[] = []): Item {
    const key = this.appFakePageService.createPageKey(text);
    const url = this.appFakePageService.createPageUrl(text);

    return this.createItem(key, url, text, children);
  }

  private createItem(key: string, url: string, text: string, children: Item[] = []): Item {
    const selected = this.pageService.key() === key;

    return {
      key,
      text,
      url,
      children,
      selected,
    } as Item;
  }
}
