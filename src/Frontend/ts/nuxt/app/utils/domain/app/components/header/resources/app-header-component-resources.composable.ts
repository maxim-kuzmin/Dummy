import type { ResourcesModel } from '~/utils/shared/resources/resources.types'
import type { AppHeaderComponentResourcesModel } from './app-header-component-resources.types'

export const useAppHeaderComponentResources = (
  resourcesModel: ResourcesModel,
): AppHeaderComponentResourcesModel => {
  const { translate } = resourcesModel

  return {
    getTitle(): string {
      return translate('app.components.app-header-component.title')
    },
  }
}
