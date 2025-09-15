import { getPageService } from '~/utils/shared/page/page.service'
import type { PageUrlOptions } from '~/utils/shared/page/page.types'
import {
  AppFakePageData,
  type AppFakePageDataLoadCommand,
  type AppFakePageDataQuery,
} from './app-fake-page.types'

export class AppFakePageService {
  private readonly pageService = getPageService()

  readonly pageData = new AppFakePageData()

  createPageKey(params: AppFakePageDataQuery): string {
    return `Fake:${params.id}`
  }

  createPageUrlOptions(query: AppFakePageDataQuery): PageUrlOptions {
    return {
      routeName: 'fake-id',
      routeParams: {
        id: query.id,
      },
    }
  }

  loadPageData(command: AppFakePageDataLoadCommand): void {
    const pageKey = this.createPageKey({ id: command.id })

    this.pageService.key.value = pageKey
    this.pageService.title.value = command.title

    this.pageData.key.value = pageKey
  }
}

const instanceOfAppFakePageService = new AppFakePageService()

export function getAppFakePageService(): AppFakePageService {
  return instanceOfAppFakePageService
}
