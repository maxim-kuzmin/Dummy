import { getAppFakePageService } from './app-fake-page.service'
import { useAppFakePageResources } from './resources/app-fake-page-resources.composable'
import {
  AppFakePageParameters,
   type AppFakePageModel,
} from './app-fake-page.types'
import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'

const storeKey = 'app-fake-page'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageResources = useAppFakePageResources()
  const pageStore = usePageStore()
  const route = useRoute()

  const appFakePageService = getAppFakePageService()

  const clickCount = useState(`${storeKey}.clickCount`, () => 0)
  const pageKey = useState(`${storeKey}.pageKey`, () => '')

  watchEffect(load)

  function load() {
    const id = String(route.params[AppFakePageParameters.id.name])

    const pageNumber = Number(
      route.query[AppFakePageParameters.pageNumber.name] ??
        AppFakePageParameters.pageNumber.defaultValue,
    )

    pageStore.value = {
      pageKey: appFakePageService.createPageKey({ id, pageNumber }),
      pageTitle: appFakePageResources.getTitle(id)
    }

    pageKey.value = pageStore.value.pageKey
  }

  return {
    clickCount,
    pageKey,
    click() {
      clickCount.value++
    },
  }
}
