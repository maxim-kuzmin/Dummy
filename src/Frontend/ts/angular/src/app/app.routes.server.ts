import { RenderMode, ServerRoute } from '@angular/ssr';
import { AppRouterPaths } from '../utils/domain/app/app.types';

export const serverRoutes: ServerRoute[] = [
  {
    path: AppRouterPaths.app.fake,
    renderMode: RenderMode.Server,
  },
  {
    path: AppRouterPaths.app.notFound,
    renderMode: RenderMode.Prerender,
  },
];
