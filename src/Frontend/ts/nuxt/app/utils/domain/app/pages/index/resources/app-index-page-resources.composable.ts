import { useResources } from '~/utils/infrastructure/resources/resources.composable'
import type { AppIndexPageResourcesModel } from './app-index-page-resources.types'

export const useAppIndexPageResources = (): AppIndexPageResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(): string {
      return translate('app.pages.app-index-page.title')
    },
  }
}
