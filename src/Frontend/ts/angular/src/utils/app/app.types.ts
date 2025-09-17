export const parameterNames = {
  id: 'id',
  pageNumber: 'pn',
} as const;

export const paths = {
  about: 'about',
  default: '**',
  fake: `fake/:${parameterNames.id}`,
  index: '',
} as const;
