import { signal } from '@angular/core';

export interface AppLanguageComponentItem {
  code: string;
  name: string;
  selected: boolean;
  url: string;
}

export class AppLanguageComponentData {
  readonly items = signal<AppLanguageComponentItem[]>([]);
  readonly menuStyle = signal({ visibility: 'hidden' });
  title = '';
}
