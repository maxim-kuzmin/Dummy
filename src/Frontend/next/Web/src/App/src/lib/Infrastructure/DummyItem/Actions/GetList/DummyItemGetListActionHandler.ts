import {
  AppApiClient,
  DummyItemGetListActionRequest,
  DummyItemGetListActionHandler,
  createAppApiRequestWithBody,
  DummyItemGetListActionDTO,
  createDummyItemGetListActionDTO,
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createDummyItemGetListActionHandler({
  appApiClient
}: Options): DummyItemGetListActionHandler {
  async function handle(request: DummyItemGetListActionRequest): Promise<DummyItemGetListActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      query: {
        ...(request.query.page && {
          'itemsPerPage': request.query.page.size,
        }),
        ...(request.query.filter?.fullTextSearchQuery && {
          'query': request.query.filter?.fullTextSearchQuery
        }),
      },
      endpoint: `${indexContext.dummyItem.actions.settings.rootPath}/page/${request.query.page?.number ?? 1}`,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    const appApiResponse = await appApiClient.get<DummyItemGetListActionDTO>(appApiRequest);

    return appApiResponse.data ?? createDummyItemGetListActionDTO();
  }

  return {
    handle
  };
}
