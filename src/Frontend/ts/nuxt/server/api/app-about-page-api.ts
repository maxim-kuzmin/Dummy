import { useAppAboutPageResources } from '~/utils/domain/app/pages/about/resources/app-about-page-resources.composable'
import type { AppAboutPageData } from '~/utils/domain/app/pages/about/app-about-page.types'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)

  const appAboutPageResourcesModel = useAppAboutPageResources(resourcesModel)

  return {
    pageTitle: appAboutPageResourcesModel.getTitle(),
  } as AppAboutPageData
})
