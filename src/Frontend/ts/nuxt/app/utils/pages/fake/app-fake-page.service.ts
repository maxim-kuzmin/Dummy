import type { RouteParamsRawGeneric } from 'vue-router'
import { getPageService } from '~/utils/shared/page/page.service'
import type { PageData, PageRouteParams } from './app-fake-page.types'

export class AppFakePageService {
  private readonly pageService = getPageService()

  readonly routeName = 'fake-id'

  readonly pageData: PageData = {
    key: this.pageService.key,
  }

  createPageKey(params: PageRouteParams): string {
    return `Fake:${params.id}`
  }

  createRouteParams(
    params: PageRouteParams,
  ): RouteParamsRawGeneric | undefined {
    return {
      id: params.id,
    }
  }

  loadPageData(id: string, translate: (key: string, list?: unknown[]) => string): void {
    this.pageService.key.value = this.createPageKey({ id })

    this.pageService.title.value = translate('page.fake.title', [id])
  }
}

const instanceOfAppFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return instanceOfAppFakePageService
}
