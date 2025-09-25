import { UrlTree } from '@angular/router';

export interface AppNavComponentItem {
  children: AppNavComponentItem[];
  key: string;
  selected: boolean;
  text: string;
  urlTree: UrlTree;
}
