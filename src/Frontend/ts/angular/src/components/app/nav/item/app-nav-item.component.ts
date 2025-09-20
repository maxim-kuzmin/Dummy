import { Component, forwardRef, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AppNavItemComponentInput } from '~/utils/domain/app/components/nav/item/app-nav-item-component.types';
import { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types';
import { AppNavComponentItem } from '~/utils/domain/app/components/nav/app-nav-component.types';
import { AppNavItems } from '../items/app-nav-items.component';

@Component({
  selector: 'li[app-nav-item]',
  templateUrl: './app-nav-item.component.html',
  imports: [RouterLink, forwardRef(() => AppNavItems)],
})
export class AppNavItem {
  readonly input = input.required<AppNavItemComponentInput>();

  protected get item(): AppNavComponentItem {
    return this.input().item;
  }

  protected createItemsComponentInput(
    item: AppNavComponentItem
  ): AppNavItemsComponentInput {
    return { items: item.children };
  }
}
