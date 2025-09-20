import { useResources } from '~/utils/infrastructure/resources/resources.composable'
import type { AppNotFoundPageResourcesModel } from './app-not-found-page-resources.types'

export const useAppNotFoundPageResources = (): AppNotFoundPageResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(): string {
      return translate('app.pages.app-not-found-page.title')
    },
  }
}
