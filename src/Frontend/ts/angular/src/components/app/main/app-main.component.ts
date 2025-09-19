import { Component, effect, inject } from '@angular/core';
import { AppMainComponentModel } from '~/utils/domain-use-cases/app/components/main/app-main-component.model';

@Component({
  selector: 'main[app-main]',
  templateUrl: './app-main.component.html',
  providers: [AppMainComponentModel],
})
export class AppMain {
  private readonly model = inject(AppMainComponentModel, { self: true });

  protected get title() {
    return this.model.title();
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
