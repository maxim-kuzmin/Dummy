import { Component, forwardRef, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Item } from '../app-nav.types';
import { AppNavItems } from '../items/app-nav-items.component';

@Component({
  selector: 'li[app-nav-item]',
  templateUrl: './app-nav-item.component.html',
  imports: [RouterLink, forwardRef(() => AppNavItems)],
})
export class AppNavItem {
  data = input.required<Item>();
}
