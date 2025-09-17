import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppNotFoundPageService {
  createPageKey(): string {
    return 'NotFound';
  }
}
