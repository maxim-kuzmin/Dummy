import { Component, effect, inject } from '@angular/core';
import { AppNavItemsComponentInput } from '~/utils/app/components/nav/items/app-nav-items-component.types';
import { AppNavComponentService } from '~/utils/app/components/nav/app-nav-component.service';
import { AppNavItems } from './items/app-nav-items.component';

@Component({
  selector: 'nav[app-nav]',
  templateUrl: './app-nav.component.html',
  imports: [AppNavItems],
})
export class AppNav {
  private readonly service = inject(AppNavComponentService);

  protected get itemsComponentInput():AppNavItemsComponentInput {
    return {
      items: this.service.items()
    }
  }

  constructor() {
    effect(() => {
      this.service.load();
    });
  }
}
