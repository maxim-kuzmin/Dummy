import { RenderMode, ServerRoute } from '@angular/ssr';
import { paths } from '../utils/app/app.types';

export const serverRoutes: ServerRoute[] = [
  {
    path: paths.fake,
    renderMode: RenderMode.Server,
  },
  {
    path: paths.default,
    renderMode: RenderMode.Prerender,
  },
];
