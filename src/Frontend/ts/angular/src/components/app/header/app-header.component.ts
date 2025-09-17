import { Component, effect, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AppHeaderComponentModel } from '~/utils/app/components/header/app-header-component.model';
import { AppLanguage } from '../language/app-language.component';

@Component({
  selector: 'header[app-header]',
  templateUrl: './app-header.component.html',
  imports: [AppLanguage, RouterLink],
  providers: [AppHeaderComponentModel],
})
export class AppHeader {
  private readonly model = inject(AppHeaderComponentModel, { self: true });

  protected get indexPageName() {
    return this.model.indexPageName;
  }

  protected get indexPageUrlTree() {
    return this.model.indexPageUrlTree;
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }
}
