import { Component, effect, inject } from '@angular/core';
import { RouterLink, UrlTree } from '@angular/router';
import { AppHeaderComponentStoreService } from '~/utils/domain/app/components/header/store/app-header-component-store.service';
import { AppHeaderComponentModel } from '~/utils/domain/app/components/header/app-header-component.model';
import { AppLanguage } from '../language/app-language.component';

@Component({
  selector: 'header[app-header]',
  templateUrl: './app-header.component.html',
  imports: [RouterLink, AppLanguage],
  providers: [AppHeaderComponentModel],
})
export class AppHeader {
  private readonly appHeaderComponentModel = inject(AppHeaderComponentModel, {
    self: true,
  });
  private readonly appHeaderComponentStoreService = inject(
    AppHeaderComponentStoreService
  );

  protected get indexPageName(): string {
    return this.appHeaderComponentStoreService.indexPageName();
  }

  protected get indexPageUrlTree(): UrlTree {
    return this.appHeaderComponentStoreService.indexPageUrlTree();
  }

  constructor() {
    effect(() => {
      this.appHeaderComponentModel.load();
    });
  }
}
