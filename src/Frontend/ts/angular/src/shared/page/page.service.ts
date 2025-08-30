import { Injectable, signal } from '@angular/core';
import { PageKeyEnum } from './page.types';

@Injectable({
  providedIn: 'root',
})
export class PageService {
  key = signal(PageKeyEnum.NotFound);
  title = signal('');
}
