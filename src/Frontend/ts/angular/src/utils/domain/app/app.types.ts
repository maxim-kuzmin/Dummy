export const AppParameterNames = {
  id: 'id',
  pageNumber: 'pn',
} as const;

export const AppRouterPaths = {
  app: {
    about: 'about',
    fake: `fake/:${AppParameterNames.id}`,
    index: '',
    notFound: '**',
  },
} as const;
