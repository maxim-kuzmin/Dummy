import type { AppFooterComponentModel } from './app-footer-component.types'
import { useAppFooterComponentResources } from './resources/app-footer-component-resources.composable'

const storeKey = 'app-footer-component'

export const useAppFooterComponent = (): AppFooterComponentModel => {
  const appFooterComponentResources = useAppFooterComponentResources()

  const title = useState(`${storeKey}.title`, () => '')

  watchEffect(load)

  function load() {
    title.value = appFooterComponentResources.getTitle()
  }
  return { title }
}
