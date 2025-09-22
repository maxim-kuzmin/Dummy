import { Routes } from '@angular/router';
import { RouterPaths } from '~/utils/infrastructure/router/router.types';

export const routes: Routes = [
  {
    path: RouterPaths.app.about,
    loadComponent: () =>
      import('~/pages/app/about/app-about-page.component').then(
        (m) => m.AppAboutPage
      ),
  },
  {
    path: RouterPaths.app.fake,
    loadComponent: () =>
      import('~/pages/app/fake/app-fake-page.component').then(
        (m) => m.AppFakePage
      ),
  },
  {
    path: RouterPaths.app.index,
    loadComponent: () =>
      import('~/pages/app/index/app-index-page.component').then(
        (m) => m.AppIndexPage
      ),
  },
  {
    path: RouterPaths.app.notFound,
    loadComponent: () =>
      import('~/pages/app/not-found/app-not-found-page.component').then(
        (m) => m.AppNotFoundPage
      ),
  },
];
