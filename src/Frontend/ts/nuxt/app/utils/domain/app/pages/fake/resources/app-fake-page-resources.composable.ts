import { useResources } from '~/utils/infrastructure/resources/resources.composable'
import type { AppFakePageResourcesModel } from './app-fake-page-resources.types'

export const useAppFakePageResources = (): AppFakePageResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(id: string): string {
      return translate('app.pages.app-fake-page.title', [id])
    },
  }
}
