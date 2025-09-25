import { Injectable, Signal, signal } from '@angular/core';
import { PageStoreDataQuery } from './page-store.types';

@Injectable({
  providedIn: 'root',
})
export class PageStoreService {
  private readonly _pageKey = signal('');
  private readonly _pageTitle = signal('');

  get pageKey(): Signal<string> {
    return this._pageKey;
  }

  get pageTitle(): Signal<string> {
    return this._pageTitle;
  }

  load(data: PageStoreDataQuery): void {
    this._pageKey.set(data.pageKey);
    this._pageTitle.set(data.pageTitle);
  }
}
