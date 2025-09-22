import { AppParameterNames } from '~/utils/domain/app/app.types';
import { PageDataQuery, PageParameter } from '~/utils/shared/page/page.types';

export interface AppFakePageDataQuery extends PageDataQuery {
  readonly id: string;
  readonly pageNumber: number;
}

export const appFakePageParameters = {
  id: new PageParameter(AppParameterNames.id, ''),
  pageNumber: new PageParameter(AppParameterNames.pageNumber, 1),
};
