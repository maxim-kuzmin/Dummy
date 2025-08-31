import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PageService {
  key = signal('');
  title = signal('');
}
