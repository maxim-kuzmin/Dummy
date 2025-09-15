import { getPageService } from '~/utils/shared/page/page.service'
import type { PageUrlOptions } from '~/utils/shared/page/page.types'
import type { AppIndexPageDataLoadCommand } from './app-index-page.types'

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

  loadPageData(command: AppIndexPageDataLoadCommand): void {
    const pageKey = this.createPageKey()

    this.pageService.key.value = pageKey
    this.pageService.title.value = command.title
  }
}

const instanceOfAppIndexPageService = new AppIndexPageService()

export function getAppIndexPageService(): AppIndexPageService {
  return instanceOfAppIndexPageService
}
