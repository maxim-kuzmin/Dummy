import { HttpParameterNames } from '~/utils/shared/http/http.types';
import { PageParameter } from '~/utils/shared/page/page.types';

export const AppFakePageParameters = {
  id: new PageParameter(HttpParameterNames.id, ''),
  pageNumber: new PageParameter(HttpParameterNames.pageNumber, 1),
} as const;
