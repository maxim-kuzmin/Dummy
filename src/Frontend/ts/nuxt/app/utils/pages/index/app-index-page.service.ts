import type { RouteParamsRawGeneric } from 'vue-router'
import { getPageService } from '~/utils/shared/page/page.service'

export class AppIndexPageService {
  private readonly pageService = getPageService()

  readonly routeName = 'index'

  createPageKey(): string {
    return 'Index'
  }

  createRouteParams(): RouteParamsRawGeneric | undefined {
    return undefined
  }

  loadPageData(translate: (key: string, list?: unknown[]) => string): void {
    this.pageService.key.value = this.createPageKey()

    this.pageService.title.value = translate('page.index.title')
  }
}

const instanceOfAppIndexPageService = new AppIndexPageService()

export function getAppIndexPageService(): AppIndexPageService {
  return instanceOfAppIndexPageService
}
