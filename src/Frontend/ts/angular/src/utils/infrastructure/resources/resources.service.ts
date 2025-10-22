import { Injectable } from '@angular/core';
import { ResourcesModel } from '~/utils/shared/resources/resources.types';

@Injectable({
  providedIn: 'root',
})
export class ResourcesService implements ResourcesModel {
  translate(
    key: string,
    parameters?: unknown[] | Record<string, unknown>
  ): string {
    switch (key) {
      case 'app_components_app-footer-component_title':
        return $localize`:@@app_components_app-footer-component_title:@@`;
      case 'app_components_app-header-component_title':
        return $localize`:@@app_components_app-header-component_title:@@`;
      case 'app_pages_app-about-page_title':
        return $localize`:@@app_pages_app-about-page_title:@@`;
      case 'app_pages_app-fake-page_title': {
        const id = this.getParameter('id', 0, parameters);
        const pageNumber = this.getParameter('pageNumber', 1, parameters);

        return $localize`:@@app_pages_app-fake-page_title:@@${id}${pageNumber}`;
      }
      case 'app_pages_app-index-page_title':
        return $localize`:@@app_pages_app-index-page_title:@@`;
      case 'app_pages_app-not-found-page_title':
        return $localize`:@@app_pages_app-not-found-page_title:@@`;
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
          return String(parameters[index]);
        } else {
          throw Error(
            `ResourcesService: Parameter index ${index} is not present in parameters array`
          );
        }
      } else {
        if (name in parameters) {
          return String(parameters[name]);
        } else {
          throw Error(
            `ResourcesService: Parameter name "${name}" is not present in parameters record`
          );
        }
      }
    } else {
      throw Error(`ResourcesService: No parameters specified`);
    }
  }
}
