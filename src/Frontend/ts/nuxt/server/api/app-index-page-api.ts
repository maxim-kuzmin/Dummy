import { useAppIndexPageResources } from '~/utils/domain/app/pages/index/resources/app-index-page-resources.composable'
import type { AppIndexPageData } from '~/utils/domain/app/pages/index/app-index-page.types'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)

  const appIndexPageResourcesModel = useAppIndexPageResources(resourcesModel)

  return {
    pageTitle: appIndexPageResourcesModel.getTitle(),
  } as AppIndexPageData
})
