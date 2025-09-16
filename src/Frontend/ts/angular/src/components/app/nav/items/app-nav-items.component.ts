import { Component, input } from '@angular/core';
import { AppNavComponentItem } from '~/utils/app/components/nav/app-nav-component.types';
import { AppNavItemsComponentData } from '~/utils/app/components/nav/items/app-nav-items-component.types';
import { AppNavItem } from '../item/app-nav-item.component';

@Component({
  selector: 'ul[app-nav-items]',
  templateUrl: './app-nav-items.component.html',
  imports: [AppNavItem],
})
export class AppNavItems {
  readonly items = input.required<AppNavComponentItem[]>();

  protected readonly data = {
    items: this.items,
  } as AppNavItemsComponentData;
}
