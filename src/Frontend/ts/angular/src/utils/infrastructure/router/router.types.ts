import { HttpParameterNames } from "~/utils/shared/http/http.types";

export const RouterPaths = {
  app: {
    about: 'about',
    fake: `fake/:${HttpParameterNames.id}`,
    index: '',
    notFound: '**',
  },
} as const;
