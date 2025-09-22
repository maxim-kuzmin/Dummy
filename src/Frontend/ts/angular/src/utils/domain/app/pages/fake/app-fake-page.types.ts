import { HttpParameterNames } from '~/utils/shared/http/http.types';
import { PageDataQuery, PageParameter } from '~/utils/shared/page/page.types';

export interface AppFakePageDataQuery extends PageDataQuery {
  readonly id: string;
  readonly pageNumber: number;
}

export const appFakePageParameters = {
  id: new PageParameter(HttpParameterNames.id, ''),
  pageNumber: new PageParameter(HttpParameterNames.pageNumber, 1),
};
