import { inject, Injectable } from '@angular/core';
import { ResourcesService } from '~/utils/infrastructure/resources/resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppHeaderComponentResourcesService {
  private readonly resourcesService = inject(ResourcesService)

  getTitle() {
    return this.resourcesService.translate('app.components.app-header-component.title');
  }
}
