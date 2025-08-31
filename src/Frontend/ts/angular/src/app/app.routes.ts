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
      import('./about/page/app-about-page.component').then(
        (m) => m.AppAboutPage
      ),
  },
  {
    path: fakePagePath,
    loadComponent: () =>
      import('./fake/page/app-fake-page.component').then((m) => m.AppFakePage),
  },
  {
    path: indexPagePath,
    loadComponent: () =>
      import('./index/page/app-index-page.component').then(
        (m) => m.AppIndexPage
      ),
  },
  {
    path: defaultPath,
    loadComponent: () =>
      import('./not-found/page/app-not-found-page.component').then(
        (m) => m.AppNotFoundPage
      ),
  },
];
