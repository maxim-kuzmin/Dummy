import { Component, effect, inject } from '@angular/core';
import { AppFooterComponentModel } from '~/utils/domain/app/components/footer/app-footer-component.model';

@Component({
  selector: 'footer[app-footer]',
  templateUrl: './app-footer.component.html',
  providers: [AppFooterComponentModel],
})
export class AppFooter {
  private readonly model = inject(AppFooterComponentModel, { self: true });

  protected get title(): string {
    return this.model.title;
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
