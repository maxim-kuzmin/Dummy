import { Signal } from '@angular/core';
import { Item } from '../app-nav.types';

export interface ItemsComponentData {
  readonly items: Signal<Item[]>;
}
