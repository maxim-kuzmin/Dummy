import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'about',
    loadComponent: () =>
      import('./about/app-about-page.component').then((m) => m.AppAboutPage),
  },
  {
    path: '',
    loadComponent: () =>
      import('./index/app-index-page.component').then((m) => m.AppIndexPage),
  },
];
