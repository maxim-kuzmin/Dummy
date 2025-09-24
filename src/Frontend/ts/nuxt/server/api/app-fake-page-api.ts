import { getAppFakePageApiService } from '~/utils/domain/app/pages/fake/api/app-fake-page-api.service'
import type { AppFakePageApiData } from '~/utils/domain/app/pages/fake/api/app-fake-page-api.types'
import { useAppFakePageResources } from '~/utils/domain/app/pages/fake/resources/app-fake-page-resources.composable'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)
  const appFakePageResourcesModel = useAppFakePageResources(resourcesModel)
  const appFakePageApiService = getAppFakePageApiService()

  const dataQuery = appFakePageApiService.getDataQueryFromRequest(event)

  return {
    pageTitle: appFakePageResourcesModel.getTitle(dataQuery.id, dataQuery.pageNumber),
  } as AppFakePageApiData
})
