import { inject, Injectable } from '@angular/core';
import { ResourcesService } from '~/utils/infrastructure/resources/resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageResourcesService {
  private readonly resourcesService = inject(ResourcesService)

  getTitle() {
    return this.resourcesService.translate('app.pages.app-about-page.title');
  }
}
