import type { ResourcesModel } from '~/utils/shared/resources/resources.types'
import type { AppAboutPageResourcesModel } from './app-about-page-resources.types'

export const useAppAboutPageResources = (
  resourcesModel: ResourcesModel,
): AppAboutPageResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(): string {
      return translate('app_pages_app-about-page_title')
    },
  }
}
