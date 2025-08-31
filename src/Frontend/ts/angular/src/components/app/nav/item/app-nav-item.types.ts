import { Signal } from '@angular/core';
import { Item } from '../app-nav.types';

export interface ItemComponentData {
  readonly item: Signal<Item>;
}
