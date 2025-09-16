import { Component, computed, effect, inject } from '@angular/core';
import { AppNavItems } from './items/app-nav-items.component';
import { AppNavComponentService } from '~/utils/app/components/nav/app-nav-component.service';

@Component({
  selector: 'nav[app-nav]',
  templateUrl: './app-nav.component.html',
  imports: [AppNavItems],
})
export class AppNav {
  private readonly service = inject(AppNavComponentService);

  protected readonly data = this.service.componentData;

  constructor() {
    effect(() => {
      this.service.loadComponentData();
    });
  }
}
