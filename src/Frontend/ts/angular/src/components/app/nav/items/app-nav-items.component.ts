import { Component, input } from '@angular/core';
import { Item } from '../app-nav.types';
import { AppNavItem } from '../item/app-nav-item.component';

@Component({
  selector: 'ul[app-nav-items]',
  templateUrl: './app-nav-items.component.html',
  imports: [AppNavItem],
})
export class AppNavItems {
  data = input.required<Item[]>();
}
