import { Component, forwardRef, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AppNavComponentItem } from '~/utils/app/components/nav/app-nav-component.types';
import { AppNavItemComponentData } from '~/utils/app/components/nav/item/app-nav-item-component.types';
import { AppNavItems } from '../items/app-nav-items.component';

@Component({
  selector: 'li[app-nav-item]',
  templateUrl: './app-nav-item.component.html',
  imports: [RouterLink, forwardRef(() => AppNavItems)],
})
export class AppNavItem {
  readonly item = input.required<AppNavComponentItem>();

  protected readonly data = {
    item: this.item,
  } as AppNavItemComponentData;
}
