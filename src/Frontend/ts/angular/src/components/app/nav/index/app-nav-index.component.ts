import { Component, effect, inject } from '@angular/core';
import { AppNavIndexComponentStoreService } from '~/utils/domain/app/components/nav/index/store/app-nav-index-component-store.service';
import { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types';
import { AppNavIndexComponentModel } from '~/utils/domain/app/components/nav/index/app-nav-index-component.model';
import { AppNavItems } from '../items/app-nav-items.component';

@Component({
  selector: 'nav[app-nav-index]',
  templateUrl: './app-nav-index.component.html',
  imports: [AppNavItems],
  providers: [AppNavIndexComponentModel],
})
export class AppNavIndex {
  private readonly appNavIndexComponentModel = inject(
    AppNavIndexComponentModel,
    { self: true }
  );
  private readonly appNavIndexComponentStoreService = inject(
    AppNavIndexComponentStoreService
  );

  protected get itemsComponentInput(): AppNavItemsComponentInput {
    return {
      items: this.appNavIndexComponentStoreService.items(),
    };
  }

  constructor() {
    effect(() => {
      this.appNavIndexComponentModel.load();
    });
  }
}
