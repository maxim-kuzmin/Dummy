import { Routes } from '@angular/router';
import { paths } from '~/utils/domain-use-cases/app/app.types';

export const routes: Routes = [
  {
    path: paths.about,
    loadComponent: () =>
      import('./pages/about/app-about-page.component').then(
        (m) => m.AppAboutPage
      ),
  },
  {
    path: paths.fake,
    loadComponent: () =>
      import('./pages/fake/app-fake-page.component').then((m) => m.AppFakePage),
  },
  {
    path: paths.index,
    loadComponent: () =>
      import('./pages/index/app-index-page.component').then(
        (m) => m.AppIndexPage
      ),
  },
  {
    path: paths.default,
    loadComponent: () =>
      import('./pages/not-found/app-not-found-page.component').then(
        (m) => m.AppNotFoundPage
      ),
  },
];
