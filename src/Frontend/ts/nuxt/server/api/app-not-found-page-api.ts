import { useAppNotFoundPageResources } from '~/utils/domain/app/pages/not-found/resources/app-not-found-page-resources.composable'
import type { AppNotFoundPageData } from '~/utils/domain/app/pages/not-found/app-not-found-page.types'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)

  const appNotFoundPageResourcesModel = useAppNotFoundPageResources(resourcesModel)

  return {
    pageTitle: appNotFoundPageResourcesModel.getTitle(),
  } as AppNotFoundPageData
})
