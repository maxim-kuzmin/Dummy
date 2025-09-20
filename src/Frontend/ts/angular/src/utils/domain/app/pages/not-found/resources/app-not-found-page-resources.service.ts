import { inject, Injectable } from '@angular/core';
import { ResourcesService } from '~/utils/infrastructure/resources/resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppNotFoundPageResourcesService {
  private readonly resourcesService = inject(ResourcesService)

  getTitle() {
    return this.resourcesService.translate('app.pages.app-not-found-page.title');
  }
}
