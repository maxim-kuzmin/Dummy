import { getPageService } from '~/utils/shared/page/page.service'
import { getAppFakePageService } from './app-fake-page.service'
import {
  AppFakePageData,
  appFakePageParameters,
  type AppFakePageModel,
} from './app-fake-page.types'

export const useAppFakePage = (): AppFakePageModel => {
  const { t } = useI18n()
  const route = useRoute()

  const appFakePageService = getAppFakePageService()
  const pageService = getPageService()

  const data = new AppFakePageData()

  watchEffect(() => {
    const id = String(route.params[appFakePageParameters.id.name])

    const pageNumber = Number(
      route.query[appFakePageParameters.pageNumber.name] ??
        appFakePageParameters.pageNumber.defaultValue,
    )

    const pageKey = appFakePageService.createPageKey({ id, pageNumber })

    pageService.key.value = pageKey
    pageService.title.value = t('page.fake.title', [id])

    data.key.value = pageKey
  })

  return {
    ...data,
    click() {
      data.clickCount.value++
    },
  }
}
