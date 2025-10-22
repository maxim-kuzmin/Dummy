import type { ResourcesModel } from '~/utils/shared/resources/resources.types'
import type { AppNotFoundPageResourcesModel } from './app-not-found-page-resources.types'

export const useAppNotFoundPageResources = (
  resourcesModel: ResourcesModel,
): AppNotFoundPageResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(): string {
      return translate('app_pages_app-not-found-page_title')
    },
  }
}
