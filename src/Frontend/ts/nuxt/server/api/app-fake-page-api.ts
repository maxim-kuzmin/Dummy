import { useAppFakePageResources } from '~/utils/domain/app/pages/fake/resources/app-fake-page-resources.composable'
import {
  type AppFakePageData,
  AppFakePageParameters,
} from '~/utils/domain/app/pages/fake/app-fake-page.types'
import { useServerResources } from '~/utils/infrastructure/resources/server-resources.composable'

export default defineEventHandler(async (event) => {
  const resourcesModel = await useServerResources(event)

  const appFakePageResourcesModel = useAppFakePageResources(resourcesModel)

  const queryParams = getQuery(event)

  const id = String(
    queryParams[AppFakePageParameters.id.name] ??
      AppFakePageParameters.id.defaultValue,
  )

  const pageNumber = Number(
    queryParams[AppFakePageParameters.pageNumber.name] ??
      AppFakePageParameters.pageNumber.defaultValue,
  )

  return {
    pageTitle: appFakePageResourcesModel.getTitle(id, pageNumber),
  } as AppFakePageData
})
