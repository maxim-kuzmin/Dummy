import { WritableSignal } from '@angular/core';

export interface ComponentData {
  currentLanguageName: string;
  readonly languages: WritableSignal<Language[]>;
}

export interface Language {
  code: string;
  name: string;
  url: string;
  selected: boolean;
}
