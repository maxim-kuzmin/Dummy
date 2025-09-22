import { useClientResources } from '~/utils/infrastructure/resources/client-resources.composable'
import type { AppFooterComponentModel } from './app-footer-component.types'
import { useAppFooterComponentResources } from './resources/app-footer-component-resources.composable'

const storeKey = 'app-footer-component'

export const useAppFooterComponent = (): AppFooterComponentModel => {
  const resourcesModel = useClientResources()

  const appFooterComponentResourcesModel = useAppFooterComponentResources(resourcesModel)

  const title = useState(`${storeKey}.title`, () => '')

  watchEffect(load)

  function load() {
    title.value = appFooterComponentResourcesModel.getTitle()
  }

  return { title }
}
