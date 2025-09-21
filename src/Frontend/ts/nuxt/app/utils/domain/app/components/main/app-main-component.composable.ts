import { usePage } from '~/utils/infrastructure/page/page.composable'
import type { AppMainComponentModel } from './app-main-component.types'

const storeKey = 'app-main-component'

export const useAppMainComponent = (): AppMainComponentModel => {
  const pageModel = usePage()

  const title = useState(`${storeKey}.title`, () => '')

  onServerPrefetch(() => {
    console.log(
      'MAKC:useAppMainComponent:onServerPrefetch:before',
      pageModel.pageTitle.value,
    )

    load()

    console.log(
      'MAKC:useAppMainComponent:onServerPrefetch:after',
      pageModel.pageTitle.value,
    )
  })

  onMounted(() => {
    console.log('MAKC:useAppMainComponent:onMounted', pageModel.pageTitle.value)

    if (!title.value) {
      load()
    }
  })

  watchEffect(() => {
    console.log(
      'MAKC:useAppMainComponent:watchEffect',
      pageModel.pageTitle.value,
    )

    load()
  })

  function load(): void {
    title.value = pageModel.pageTitle.value

    console.log('MAKC:useAppMainComponent:load', pageModel.pageTitle.value)
  }

  return { title }
}
