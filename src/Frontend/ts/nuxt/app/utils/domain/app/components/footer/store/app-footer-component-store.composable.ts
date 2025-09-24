import { useClientResources } from '~/utils/infrastructure/resources/client-resources.composable'
import { useAppFooterComponentResources } from '../resources/app-footer-component-resources.composable'
import type { AppFooterComponentStoreModel } from './app-footer-component-store.types'

const storeKey = 'app-footer-component'

export const useAppFooterComponentStore = (): AppFooterComponentStoreModel => {
  const resourcesModel = useClientResources()

  const appFooterComponentResourcesModel =
    useAppFooterComponentResources(resourcesModel)

  const title = useState(`${storeKey}.title`, () => '')

  return {
    title: readonly(title),
    load(): void {
      title.value = appFooterComponentResourcesModel.getTitle()
    },
  }
}
