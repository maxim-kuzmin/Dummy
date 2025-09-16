import { WritableSignal } from "@angular/core";

export interface AppNavComponentItem {
  key: string;
  url: string;
  text: string;
  children: AppNavComponentItem[];
  selected: boolean;
}

export interface AppNavComponentData {
  readonly items: WritableSignal<AppNavComponentItem[]>;
}
