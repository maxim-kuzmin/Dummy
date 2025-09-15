import { Component, input } from '@angular/core';
import { Item } from '~/utils/app/components/nav/app-nav.types';
import { ItemsComponentData } from '~/utils/app/components/nav/items/app-nav-items.types';
import { AppNavItem } from '../item/app-nav-item.component';

@Component({
  selector: 'ul[app-nav-items]',
  templateUrl: './app-nav-items.component.html',
  imports: [AppNavItem],
})
export class AppNavItems {
  readonly items = input.required<Item[]>();

  protected readonly data = {
    items: this.items,
  } as ItemsComponentData;
}
