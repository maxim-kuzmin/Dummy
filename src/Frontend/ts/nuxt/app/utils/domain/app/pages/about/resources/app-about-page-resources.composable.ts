import { useResources } from '~/utils/infrastructure/resources/resources.composable'
import type { AppAboutPageResourcesModel } from './app-about-page-resources.types'

export const useAppAboutPageResources = (): AppAboutPageResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(): string {
      return translate('app.pages.app-about-page.title')
    },
  }
}
