import { RenderMode, ServerRoute } from '@angular/ssr';
import { RouterPaths } from '../utils/infrastructure/router/router.types';

export const serverRoutes: ServerRoute[] = [
  {
    path: RouterPaths.app.fake,
    renderMode: RenderMode.Server,
  },
  {
    path: RouterPaths.app.notFound,
    renderMode: RenderMode.Prerender,
  },
];
