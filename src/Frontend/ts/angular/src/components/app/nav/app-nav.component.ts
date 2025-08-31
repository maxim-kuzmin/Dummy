import { Component, computed, effect, inject } from '@angular/core';
import { AppNavItems } from './items/app-nav-items.component';
import { AppNavService } from './app-nav.service';

@Component({
  selector: 'nav[app-nav]',
  templateUrl: './app-nav.component.html',
  imports: [AppNavItems],
})
export class AppNav {
  private readonly service = inject(AppNavService);

  protected readonly data = this.service.componentData;

  constructor() {
    effect(() => {
      this.service.loadComponentData();
    });
  }
}
