import { inject, Injectable } from '@angular/core';
import { ResourcesService } from '~/utils/infrastructure/resources/resources.service';

@Injectable({
  providedIn: 'root',
})
export class AppFakePageResourcesService {
  private readonly resourcesService = inject(ResourcesService)

  getTitle(id: string) {
    return this.resourcesService.translate('page.fake.title', [id]);
  }
}
