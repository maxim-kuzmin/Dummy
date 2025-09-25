import { Component, effect, inject } from '@angular/core';
import { AppMainComponentStoreService } from '~/utils/domain/app/components/main/store/app-main-component-store.service';
import { AppMainComponentModel } from '~/utils/domain/app/components/main/app-main-component.model';

@Component({
  selector: 'main[app-main]',
  templateUrl: './app-main.component.html',
  providers: [AppMainComponentModel],
})
export class AppMain {
  private readonly appMainComponentModel = inject(AppMainComponentModel, {
    self: true,
  });
  private readonly appMainComponentStoreService = inject(
    AppMainComponentStoreService
  );

  protected get title(): string {
    return this.appMainComponentStoreService.title();
  }

  constructor() {
    effect(() => {
      this.appMainComponentModel.load();
    });
  }
}
