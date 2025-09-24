import type { AppIndexPageApiData } from '~/utils/domain/app/pages/index/api/app-index-page-api.types'
import { useAppIndexPageResources } from '~/utils/domain/app/pages/index/resources/app-index-page-resources.composable'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)
  const appIndexPageResourcesModel = useAppIndexPageResources(resourcesModel)

  return {
    pageTitle: appIndexPageResourcesModel.getTitle(),
  } as AppIndexPageApiData
})
