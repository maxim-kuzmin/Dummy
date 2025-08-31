import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PageService {
  readonly key = signal('');
  readonly title = signal('');
}
