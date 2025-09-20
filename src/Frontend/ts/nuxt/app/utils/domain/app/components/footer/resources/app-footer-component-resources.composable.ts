import { useResources } from '~/utils/infrastructure/resources/resources.composable'
import type { AppFooterComponentResourcesModel } from './app-footer-component-resources.types'

export const useAppFooterComponentResources = (): AppFooterComponentResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(): string {
      return translate('app.components.app-footer-component.title')
    },
  }
}
