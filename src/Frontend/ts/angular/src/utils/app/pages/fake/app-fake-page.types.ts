import { AppParameterNames } from '~/utils/app/app.types';
import { PageParameter } from '~/utils/shared/page/page.types';

export interface AppFakePageDataQuery {
  readonly id: string;
  readonly pageNumber: number;
}

export const appFakePageParameters = {
  id: new PageParameter(AppParameterNames.id, ''),
  pageNumber: new PageParameter(AppParameterNames.pageNumber, 1),
};
