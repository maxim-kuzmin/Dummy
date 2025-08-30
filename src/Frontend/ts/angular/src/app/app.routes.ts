import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'about',
    loadComponent: () =>
      import('./about/app-about-page.component').then((m) => m.AppAboutPage),
  },
  {
    path: 'fake/:id',
    loadComponent: () =>
      import('./fake/app-fake-page.component').then((m) => m.AppFakePage),
  },
  {
    path: '',
    loadComponent: () =>
      import('./index/app-index-page.component').then((m) => m.AppIndexPage),
  },
  {
    path: '**',
    loadComponent: () =>
      import('./not-found/app-not-found-page.component').then((m) => m.AppNotFoundPage),
  },
];
