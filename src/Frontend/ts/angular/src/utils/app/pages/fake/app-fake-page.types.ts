import { parameterNames } from '~/utils/app/app.types';
import { PageParameter } from '~/utils/shared/page/page.types';

export interface AppFakePageDataQuery {
  readonly id: string;
  readonly pageNumber: number;
}

export const appFakePageParameters = {
  id: new PageParameter(parameterNames.id, ''),
  pageNumber: new PageParameter(parameterNames.pageNumber, 1),
};
