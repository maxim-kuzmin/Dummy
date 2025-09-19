export const AppParameterNames = {
  id: 'id',
  pageNumber: 'pn',
} as const;

export const paths = {
  about: 'about',
  default: '**',
  fake: `fake/:${AppParameterNames.id}`,
  index: '',
} as const;
