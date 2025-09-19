import { useResources } from '~/utils/shared/resources/resources.composable'
import type { AppFakePageResourcesModel } from './app-fake-page-resources.types'

export const useAppFakePageResources = (): AppFakePageResourcesModel => {
  const { translate } = useResources()

  return {
    getTitle(id: string): string {
      return translate('page.fake.title', [id])
    },
  }
}
