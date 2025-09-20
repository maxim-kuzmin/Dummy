import { useResources } from '~/utils/infrastructure/resources/resources.composable'
import type { AppHeaderComponentResourcesModel } from './app-header-component-resources.types'

export const useAppHeaderComponentResources = (): AppHeaderComponentResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(): string {
      return translate('app.components.app-header-component.title')
    },
  }
}
