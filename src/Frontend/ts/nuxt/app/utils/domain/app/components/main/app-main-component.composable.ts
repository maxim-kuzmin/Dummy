import { usePage } from '~/utils/infrastructure/page/page.composable'
import type { AppMainComponentModel } from './app-main-component.types'

const storeKey = 'app-main-component'

export const useAppMainComponent = (): AppMainComponentModel => {
  const pageModel = usePage()

  const title = useState(`${storeKey}.title`, () => '')

  watchEffect(load)

  function load(): void {
    title.value = pageModel.pageTitle.value
  }

  return { title }
}
