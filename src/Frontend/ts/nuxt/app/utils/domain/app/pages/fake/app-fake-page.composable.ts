import { getAppFakePageService } from './app-fake-page.service'
import { useAppFakePageResources } from './resources/app-fake-page-resources.composable'
import {
  AppFakePageParameters,
  type AppFakePageModel,
} from './app-fake-page.types'
import { usePage } from '~/utils/infrastructure/page/page.composable'

const storeKey = 'app-fake-page'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageResourcesModel = useAppFakePageResources()
  const pageModel = usePage()

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

    pageModel.pageKey.value = appFakePageService.createPageKey({
      id,
      pageNumber,
    })

    pageModel.pageTitle.value = appFakePageResourcesModel.getTitle(id)

    pageKey.value = pageModel.pageKey.value
  }

  return {
    clickCount,
    pageKey,
    click() {
      clickCount.value++
    },
  }
}
