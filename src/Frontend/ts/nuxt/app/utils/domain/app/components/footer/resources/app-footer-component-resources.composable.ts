import type { ResourcesModel } from '~/utils/shared/resources/resources.types'
import type { AppFooterComponentResourcesModel } from './app-footer-component-resources.types'

export const useAppFooterComponentResources = (
  resourcesModel: ResourcesModel,
): AppFooterComponentResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(): string {
      return translate('app.components.app-footer-component.title')
    },
  }
}
