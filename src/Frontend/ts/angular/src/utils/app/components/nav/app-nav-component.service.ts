import { inject, Injectable, signal } from '@angular/core';
import { PageService } from '~/utils/shared/page/page.service';
import { AppAboutPageService } from '~/utils/app/pages/about/app-about-page.service';
import { AppFakePageService } from '~/utils/app/pages/fake/app-fake-page.service';
import { AppNavComponentData, AppNavComponentItem } from './app-nav-component.types';

@Injectable({
  providedIn: 'root',
})
export class AppNavComponentService {
  private readonly pageService = inject(PageService);
  private readonly appAboutPageService = inject(AppAboutPageService);
  private readonly appFakePageService = inject(AppFakePageService);

  readonly componentData = {
    items: signal([]),
  } as AppNavComponentData;

  loadComponentData(): void {
    this.componentData.items.set(this.createFakeItems());
  }

  private createFakeItems(): AppNavComponentItem[] {
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

  private createItemForAboutPage(): AppNavComponentItem {
    const text = $localize`:@@page.about.title:@@`;
    const key = this.appAboutPageService.createPageKey();
    const url = this.appAboutPageService.createPageUrl();

    return this.createItem(key, url, text);
  }

  private createItemForFakePage(text: string, children: AppNavComponentItem[] = []): AppNavComponentItem {
    const key = this.appFakePageService.createPageKey({id: text});
    const url = this.appFakePageService.createPageUrl({id: text});

    return this.createItem(key, url, text, children);
  }

  private createItem(key: string, url: string, text: string, children: AppNavComponentItem[] = []): AppNavComponentItem {
    const selected = this.pageService.key() === key;

    return {
      key,
      text,
      url,
      children,
      selected,
    } as AppNavComponentItem;
  }
}
