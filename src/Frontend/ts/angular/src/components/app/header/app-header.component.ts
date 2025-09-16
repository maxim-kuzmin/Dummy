import { Component, effect, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AppHeaderComponentService } from '~/utils/app/components/header/app-header-component.service';
import { AppLanguage } from '../language/app-language.component';

@Component({
  selector: 'header[app-header]',
  templateUrl: './app-header.component.html',
  imports: [AppLanguage, RouterLink],
})
export class AppHeader {
  private readonly service = inject(AppHeaderComponentService);

  protected get indexPageName() {
    return this.service.indexPageName;
  }

  protected get indexPageUrl() {
    return this.service.indexPageUrl;
  }

  constructor() {
    effect(() => {
      this.service.load();
    });
  }
}
