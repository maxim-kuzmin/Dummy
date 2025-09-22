import {
  AppFakePageParameters,
  type AppFakePageModel,
} from './app-fake-page.types'
import { useAppFakePageStore } from './store/app-fake-page-store.composable'
import { useLanguage } from '~/utils/infrastructure/language/language.composable'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageStoreModel = useAppFakePageStore()
  const languageModel = useLanguage()

  const route = useRoute()

  watchEffect(load)

  async function load() {
    const id = String(route.params[AppFakePageParameters.id.name])

    const locale = languageModel.getCurrentLanguage().code

    const pageNumber = Number(
      route.query[AppFakePageParameters.pageNumber.name] ??
        AppFakePageParameters.pageNumber.defaultValue,
    )

    await appFakePageStoreModel.load({ id, pageNumber }, { locale })
  }

  return { ...appFakePageStoreModel }
}
