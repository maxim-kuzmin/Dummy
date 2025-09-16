import { Signal } from '@angular/core';
import { AppNavComponentItem } from '../app-nav-component.types';

export interface AppNavItemComponentData {
  readonly item: Signal<AppNavComponentItem>;
}
