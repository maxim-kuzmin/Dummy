import { Signal } from '@angular/core';
import { Item } from '../app-nav.types';

export interface ItemComponentData {
  item: Signal<Item>;
}
