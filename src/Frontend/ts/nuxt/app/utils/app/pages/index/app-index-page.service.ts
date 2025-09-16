import type { PageUrlOptions } from '~/utils/shared/page/url/page-url.types'

export class AppIndexPageService {
  createPageKey(): string {
    return 'Index'
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeName: 'index',
    }
  }
}

const appIndexPageService = new AppIndexPageService()

export function getAppIndexPageService(): AppIndexPageService {
  return appIndexPageService
}
