import { Component, forwardRef, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Item } from '~/utils/app/components/nav/app-nav.types';
import { ItemComponentData } from '~/utils/app/components/nav/item/app-nav-item.types';
import { AppNavItems } from '../items/app-nav-items.component';

@Component({
  selector: 'li[app-nav-item]',
  templateUrl: './app-nav-item.component.html',
  imports: [RouterLink, forwardRef(() => AppNavItems)],
})
export class AppNavItem {
  readonly item = input.required<Item>();

  protected readonly data = {
    item: this.item,
  } as ItemComponentData;
}
