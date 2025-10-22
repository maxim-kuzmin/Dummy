import type { AppFakePageResourcesModel } from './app-fake-page-resources.types'
import type { ResourcesModel } from '~/utils/shared/resources/resources.types'

export const useAppFakePageResources = (
  resourcesModel: ResourcesModel,
): AppFakePageResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(id: string, pageNumber: number): string {
      return translate('app_pages_app-fake-page_title', {
        id: `{${id}}`,
        pageNumber,
      })
    },
  }
}
