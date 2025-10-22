import { inject, Injectable } from '@angular/core';
import { ResourcesService } from '~/utils/infrastructure/resources/resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageResourcesService {
  private readonly resourcesService = inject(ResourcesService);

  getTitle(id: string, pageNumber: number): string {
    return this.resourcesService.translate('app_pages_app-fake-page_title', {
      id: `{${id}}`,
      pageNumber,
    });
  }
}
