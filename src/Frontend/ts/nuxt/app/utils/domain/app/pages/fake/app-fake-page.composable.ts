import { getPageService } from '~/utils/infrastructure/page/page.service'
import { getAppFakePageService } from './app-fake-page.service'
import { useAppFakePageResources } from './resources/app-fake-page-resources.composable'
import {
  AppFakePageData,
  AppFakePageParameters,
  type AppFakePageModel,
} from './app-fake-page.types'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageResourcesModel = useAppFakePageResources()
  const route = useRoute()

  const appFakePageService = getAppFakePageService()
  const pageService = getPageService()

  const data = new AppFakePageData()

  watchEffect(() => {
    const id = String(route.params[AppFakePageParameters.id.name])

    const pageNumber = Number(
      route.query[AppFakePageParameters.pageNumber.name] ??
        AppFakePageParameters.pageNumber.defaultValue,
    )

    const pageKey = appFakePageService.createPageKey({ id, pageNumber })

    pageService.key.value = pageKey
    pageService.title.value = appFakePageResourcesModel.getTitle(id)

    data.key.value = pageKey
  })

  return {
    ...data,
    click() {
      data.clickCount.value++
    },
  }
}
