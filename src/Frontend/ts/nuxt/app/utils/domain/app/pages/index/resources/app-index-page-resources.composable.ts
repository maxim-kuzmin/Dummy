import type { ResourcesModel } from '~/utils/shared/resources/resources.types'
import type { AppIndexPageResourcesModel } from './app-index-page-resources.types'

export const useAppIndexPageResources = (
  resourcesModel: ResourcesModel,
): AppIndexPageResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(): string {
      return translate('app_pages_app-index-page_title')
    },
  }
}
