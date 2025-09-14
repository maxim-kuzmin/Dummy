import { Routes } from '@angular/router';
import {
  aboutPagePath,
  defaultPath,
  fakePagePath,
  indexPagePath,
} from './app.paths';

export const routes: Routes = [
  {
    path: aboutPagePath,
    loadComponent: () =>
      import('./pages/about/app-about-page.component').then(
        (m) => m.AppAboutPage
      ),
  },
  {
    path: fakePagePath,
    loadComponent: () =>
      import('./pages/fake/app-fake-page.component').then((m) => m.AppFakePage),
  },
  {
    path: indexPagePath,
    loadComponent: () =>
      import('./pages/index/app-index-page.component').then(
        (m) => m.AppIndexPage
      ),
  },
  {
    path: defaultPath,
    loadComponent: () =>
      import('./pages/not-found/app-not-found-page.component').then(
        (m) => m.AppNotFoundPage
      ),
  },
];
