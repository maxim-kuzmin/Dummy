import { getPageService } from '~/utils/shared/page/page.service'
import { getAppFakePageService } from './app-fake-page.service'
import { AppFakePageData, type AppFakePageModel } from './app-fake-page.types'

export const useAppFakePage = (): AppFakePageModel => {
  const { t } = useI18n()
  const route = useRoute()

  const appFakePageService = getAppFakePageService()
  const pageService = getPageService()

  const data = new AppFakePageData()

  watchEffect(() => {
    const idParameter = appFakePageService.parameters.id
    const pageNumberParameter = appFakePageService.parameters.pageNumber

    const id = String(route.params[idParameter.name])

    const pageNumber = Number(
      route.query[pageNumberParameter.name] ?? pageNumberParameter.defaultValue,
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
