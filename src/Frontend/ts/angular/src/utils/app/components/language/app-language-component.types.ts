import { Signal, WritableSignal } from '@angular/core';

export interface AppLanguageComponentItem {
  code: string;
  name: string;
  url: string;
  selected: boolean;
}

export interface AppLanguageComponentData {
  currentLanguageName: string;
  readonly items: WritableSignal<AppLanguageComponentItem[]>;
  readonly menuStyle: Signal<{ visibility: string }>;
}
