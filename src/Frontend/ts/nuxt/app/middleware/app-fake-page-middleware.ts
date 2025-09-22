import { AppFakePageParameters } from '~/utils/domain/app/pages/fake/app-fake-page.types'
import { useAppFakePageStore } from '~/utils/domain/app/pages/fake/store/app-fake-page-store.composable'
import { getLanguageService } from '~/utils/infrastructure/language/language.service'

export default defineNuxtRouteMiddleware(async (to) => {
  const appFakePageStoreModel = useAppFakePageStore()

  const languageService = getLanguageService()

  const routeParams = to.params
  const queryParams = to.query

  const id = String(
    routeParams[AppFakePageParameters.id.name] ??
      AppFakePageParameters.id.defaultValue,
  )

  const locale = languageService.getLanguageCodeFromPath(to.path)

  const pageNumber = Number(
    queryParams[AppFakePageParameters.pageNumber.name] ??
      AppFakePageParameters.pageNumber.defaultValue,
  )

  await appFakePageStoreModel.load({ id, locale, pageNumber })
})
