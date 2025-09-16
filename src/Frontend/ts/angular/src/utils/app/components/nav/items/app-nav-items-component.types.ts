import { Signal } from '@angular/core';
import { AppNavComponentItem } from '../app-nav-component.types';

export interface AppNavItemsComponentData {
  readonly items: Signal<AppNavComponentItem[]>;
}
