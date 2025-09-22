import type { ResourcesModel } from '~/utils/shared/resources/resources.types'
import type { AppAboutPageResourcesModel } from './app-about-page-resources.types'

export const useAppAboutPageResources = (
  resourcesModel: ResourcesModel,
): AppAboutPageResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(): string {
      return translate('app.pages.app-about-page.title')
    },
  }
}
