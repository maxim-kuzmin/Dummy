import { Component, effect, inject } from '@angular/core';
import { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types';
import { AppNavComponentModel } from '~/utils/domain/app/components/nav/app-nav-component.model';
import { AppNavItems } from './items/app-nav-items.component';

@Component({
  selector: 'nav[app-nav]',
  templateUrl: './app-nav.component.html',
  imports: [AppNavItems],
  providers: [AppNavComponentModel],
})
export class AppNav {
  private readonly model = inject(AppNavComponentModel, { self: true });

  protected get itemsComponentInput(): AppNavItemsComponentInput {
    return {
      items: this.model.items(),
    };
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
