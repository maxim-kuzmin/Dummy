import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PageService {
  readonly pageKey = signal('');
  readonly pageTitle = signal('');
}
