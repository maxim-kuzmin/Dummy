import { Component, effect, inject } from '@angular/core';
import { AppFooterComponentStoreService } from '~/utils/domain/app/components/footer/store/app-footer-component-store.service';
import { AppFooterComponentModel } from '~/utils/domain/app/components/footer/app-footer-component.model';

@Component({
  selector: 'footer[app-footer]',
  templateUrl: './app-footer.component.html',
  providers: [AppFooterComponentModel],
})
export class AppFooter {
  private readonly appFooterComponentModel = inject(AppFooterComponentModel, {
    self: true,
  });
  private readonly appFooterComponentStoreService = inject(
    AppFooterComponentStoreService
  );

  protected get title(): string {
    return this.appFooterComponentStoreService.title();
  }

  constructor() {
    effect(() => {
      this.appFooterComponentModel.load();
    });
  }
}
