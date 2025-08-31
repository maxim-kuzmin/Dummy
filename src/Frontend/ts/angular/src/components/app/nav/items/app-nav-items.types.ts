import { Signal } from '@angular/core';
import { Item } from '../app-nav.types';

export interface ItemsComponentData {
  items: Signal<Item[]>;
}
