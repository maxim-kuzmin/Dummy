import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import type { PageData } from '~/utils/shared/page/page.types'
import { AppFakePageParameters, type AppFakePageDataQuery } from '../app-fake-page.types'
import type { AppFakePageStoreModel } from './app-fake-page-store.types'

const storeKey = 'app-fake-page'
const storeUrl = '/api/app-fake-page-api'

export const useAppFakePageStore = (): AppFakePageStoreModel => {
  const pageStoreModel = usePageStore()

  const clickCount = useState(`${storeKey}.clickCount`, () => 0)
  const pageKey = useState(`${storeKey}.pageKey`, () => '')

  return {
    clickCount,
    pageKey,
    click(): void {
      clickCount.value++
    },
    async load(dataQuery: AppFakePageDataQuery): Promise<void> {
      const query = {
        [AppFakePageParameters.id.name]: dataQuery.id,
        [AppFakePageParameters.locale.name]: dataQuery.locale,
        [AppFakePageParameters.pageNumber.name]: dataQuery.pageNumber
      }

      const res = await useFetch<PageData>(storeUrl, { query })

      const value = res.data.value!

      pageStoreModel.pageKey.value = value.pageKey
      pageStoreModel.pageTitle.value = value.pageTitle

      pageKey.value = value.pageKey
    },
  }
}
