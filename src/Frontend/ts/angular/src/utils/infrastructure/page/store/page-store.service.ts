import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PageStoreService {
  readonly pageKey = signal('');
  readonly pageTitle = signal('');
}
