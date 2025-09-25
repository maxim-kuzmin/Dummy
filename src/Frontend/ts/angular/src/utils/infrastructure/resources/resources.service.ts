import { Injectable } from '@angular/core';
import { ResourcesModel } from '~/utils/shared/resources/resources.types';

@Injectable({
  providedIn: 'root',
})
export class ResourcesService implements ResourcesModel {
  translate(key: string, parameters?: unknown[] | Record<string, unknown>): string {
    switch (key) {
      case 'app.components.app-footer-component.title':
        return $localize`:@@app.components.app-footer-component.title:@@`;
      case 'app.components.app-header-component.title':
        return $localize`:@@app.components.app-header-component.title:@@`;
      case 'app.pages.app-about-page.title':
        return $localize`:@@app.pages.app-about-page.title:@@`;
      case 'app.pages.app-fake-page.title': {
        const id = this.getParameter('id', 0, parameters);
        const pageNumber = this.getParameter('pageNumber', 1, parameters);

        return `${$localize`:@@app.pages.app-fake-page.title[0]:@@`} ${id} - ${pageNumber}`;
      }
      case 'app.pages.app-index-page.title':
        return $localize`:@@app.pages.app-index-page.title:@@`;
      case 'app.pages.app-not-found-page.title':
        return $localize`:@@app.pages.app-not-found-page.title:@@`;
      default:
        throw Error(`ResourcesService: Unknown resource key: "${key}"`);
    }
  }

  private getParameter(
    name: string,
    index: number,
    parameters?: unknown[] | Record<string, unknown>
  ): string {
    if (parameters) {
      if (Array.isArray(parameters)) {
        if (parameters.length > index) {
          return String(parameters[index])
        } else {
          throw Error(`ResourcesService: Parameter index ${index} is not present in parameters array`)
        }
      } else {
        if (name in parameters) {
          return String(parameters[name])
        } else {
          throw Error(`ResourcesService: Parameter name "${name}" is not present in parameters record`)
        }
      }
    } else {
      throw Error(`ResourcesService: No parameters specified`)
    }
  }
}
