import { RenderMode, ServerRoute } from '@angular/ssr';
import { defaultPath, fakePagePath } from './app.paths';

export const serverRoutes: ServerRoute[] = [
  {
    path: fakePagePath,
    renderMode: RenderMode.Server,
  },
  {
    path: defaultPath,
    renderMode: RenderMode.Prerender,
  },
];
