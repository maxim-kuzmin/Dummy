import { Component, input } from '@angular/core';
import { Item } from '../app-nav.types';
import { AppNavItem } from '../item/app-nav-item.component';
import { ItemsComponentData } from './app-nav-items.types';

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
