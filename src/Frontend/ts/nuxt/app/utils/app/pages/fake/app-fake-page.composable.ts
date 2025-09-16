import { getPageService } from '~/utils/shared/page/page.service'
import { getAppFakePageService } from './app-fake-page.service'
import {
  AppFakePageData,
  type AppFakePageDataQuery,
  type AppFakePageModel,
  type AppFakePageParameters,
} from './app-fake-page.types'

export const useAppFakePage = (): AppFakePageModel => {
  const { t } = useI18n()
  const route = useRoute()

  const appFakePageService = getAppFakePageService()
  const pageService = getPageService()

  const parameters = {
    id: computed(() => route.params[appFakePageService.parameterNames.id]),
    pageNumber: computed(() =>
      Number(route.query[appFakePageService.parameterNames.pageNumber] ?? 1),
    ),
  } as AppFakePageParameters

  const data = new AppFakePageData()

  watchEffect(() => {
    const dataQuery = {
      id: parameters.id.value,
      pageNumber: parameters.pageNumber.value,
    } as AppFakePageDataQuery

    const pageKey = appFakePageService.createPageKey(dataQuery)

    pageService.key.value = pageKey
    pageService.title.value = t('page.fake.title', [dataQuery.id])

    data.key.value = pageKey
  })

  return {
    ...data,
    click() {
      data.clickCount.value++
    },
  }
}
