import { WritableSignal } from '@angular/core';

export interface ComponentData {
  currentLanguageValue: string;
  readonly languages: WritableSignal<Language[]>;
}

export interface Language {
  key: string;
  value: string;
  url: string;
  selected: boolean;
}
