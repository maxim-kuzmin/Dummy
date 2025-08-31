import { WritableSignal } from "@angular/core";

export interface ComponentData {
  readonly items: WritableSignal<Item[]>;
}

export interface Item {
  key: string;
  url: string;
  text: string;
  children: Item[];
  selected: boolean;
}
