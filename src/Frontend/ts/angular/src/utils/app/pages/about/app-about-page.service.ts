import { Injectable } from '@angular/core';
import { paths } from '~/utils/app/app.types';

@Injectable({
  providedIn: 'root',
})
export class AppAboutPageService {
  createPageKey(): string {
    return 'About';
  }

  createPageUrl(): string {
    return `/${paths.about}`;
  }
}
