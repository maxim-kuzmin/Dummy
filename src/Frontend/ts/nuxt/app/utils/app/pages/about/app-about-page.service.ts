import { getPageService } from '~/utils/shared/page/page.service'
import type { PageUrlOptions } from '~/utils/shared/page/page.types'
import type { AppAboutPagePayload } from './app-about-page.types'

export class AppAboutPageService {
  private readonly pageService = getPageService()

  createPageKey(): string {
    return 'About'
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeName: 'about',
    }
  }

  loadPageData(payload: AppAboutPagePayload): void {
    const { resources } = payload

    const pageKey = this.createPageKey()

    this.pageService.key.value = pageKey
    this.pageService.title.value = resources.title
  }
}

const instanceOfAppAboutPageService = new AppAboutPageService()

export function getAppAboutPageService(): AppAboutPageService {
  return instanceOfAppAboutPageService
}
