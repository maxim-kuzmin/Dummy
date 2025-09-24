import type { AppNotFoundPageApiData } from '~/utils/domain/app/pages/not-found/api/app-not-found-page-api.types'
import { useAppNotFoundPageResources } from '~/utils/domain/app/pages/not-found/resources/app-not-found-page-resources.composable'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)
  const appNotFoundPageResourcesModel = useAppNotFoundPageResources(resourcesModel)

  return {
    pageTitle: appNotFoundPageResourcesModel.getTitle(),
  } as AppNotFoundPageApiData
})
