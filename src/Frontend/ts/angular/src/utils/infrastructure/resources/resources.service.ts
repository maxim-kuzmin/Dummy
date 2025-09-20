import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ResourcesService {
  translate(key: string, list?: unknown[]): string {
    switch (key) {
      case 'app.components.app-footer-component.title':
        return $localize`:@@app.components.app-footer-component.title:@@`;
      case 'app.components.app-header-component.title':
        return $localize`:@@app.components.app-header-component.title:@@`;
      case 'app.pages.app-about-page.title':
        return $localize`:@@app.pages.app-about-page.title:@@`;
      case 'app.pages.app-fake-page.title': {
        const id = list ? String(list[0]) : '';

        return `${$localize`:@@app.pages.app-fake-page.title:@@`} ${id}`;
      }
      case 'app.pages.app-index-page.title':
        return $localize`:@@app.pages.app-index-page.title:@@`;
      case 'app.pages.app-not-found-page.title':
        return $localize`:@@app.pages.app-not-found-page.title:@@`;
      default:
        throw Error(`ResourcesService: Unknown resource key: "${key}"`);
    }
  }
}
