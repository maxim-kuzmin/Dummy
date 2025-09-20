import { Component, input } from '@angular/core';
import { AppNavItemComponentInput } from '~/utils/domain/app/components/nav/item/app-nav-item-component.types';
import { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types';
import { AppNavComponentItem } from '~/utils/domain/app/components/nav/app-nav-component.types';
import { AppNavItem } from '../item/app-nav-item.component';

@Component({
  selector: 'ul[app-nav-items]',
  templateUrl: './app-nav-items.component.html',
  imports: [AppNavItem],
})
export class AppNavItems {
  readonly input = input.required<AppNavItemsComponentInput>();

  protected get items() {
    return this.input().items;
  }

  protected createItemComponentInput(
    item: AppNavComponentItem
  ): AppNavItemComponentInput {
    return { item };
  }
}
