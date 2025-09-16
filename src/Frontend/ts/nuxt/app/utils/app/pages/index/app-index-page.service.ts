import { getPageService } from '~/utils/shared/page/page.service'
import type { PageUrlOptions } from '~/utils/shared/page/url/page-url.types'
import type { AppIndexPagePayload } from './app-index-page.types'

export class AppIndexPageService {
  private readonly pageService = getPageService()

  createPageKey(): string {
    return 'Index'
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeName: 'index',
    }
  }

  loadPageData(payload: AppIndexPagePayload): void {
    const { resources } = payload

    const pageKey = this.createPageKey()

    this.pageService.key.value = pageKey
    this.pageService.title.value = resources.title
  }
}

const instanceOfAppIndexPageService = new AppIndexPageService()

export function getAppIndexPageService(): AppIndexPageService {
  return instanceOfAppIndexPageService
}
