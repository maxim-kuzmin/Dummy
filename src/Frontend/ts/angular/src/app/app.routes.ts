import { Routes } from '@angular/router';
import { AppRouterPaths } from '~/utils/domain/app/app.types';

export const routes: Routes = [
  {
    path: AppRouterPaths.app.about,
    loadComponent: () =>
      import('~/pages/app/about/app-about-page.component').then(
        (m) => m.AppAboutPage
      ),
  },
  {
    path: AppRouterPaths.app.fake,
    loadComponent: () =>
      import('~/pages/app/fake/app-fake-page.component').then(
        (m) => m.AppFakePage
      ),
  },
  {
    path: AppRouterPaths.app.index,
    loadComponent: () =>
      import('~/pages/app/index/app-index-page.component').then(
        (m) => m.AppIndexPage
      ),
  },
  {
    path: AppRouterPaths.app.notFound,
    loadComponent: () =>
      import('~/pages/app/not-found/app-not-found-page.component').then(
        (m) => m.AppNotFoundPage
      ),
  },
];
