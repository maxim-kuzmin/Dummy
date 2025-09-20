import { inject, Injectable } from '@angular/core';
import { ResourcesService } from '~/utils/infrastructure/resources/resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppFooterComponentResourcesService {
  private readonly resourcesService = inject(ResourcesService)

  getTitle() {
    return this.resourcesService.translate('app.components.app-footer-component.title');
  }
}
