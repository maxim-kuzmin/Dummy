import type { UrlOptions } from '~/utils/infrastructure/page/url/page-url.types'

export class AppIndexPageService {
  createPageKey(): string {
    return 'Index'
  }

  createPageUrlOptions(): UrlOptions {
    return {
      routeName: 'index',
    }
  }
}

const appIndexPageService = new AppIndexPageService()

export function getAppIndexPageService(): AppIndexPageService {
  return appIndexPageService
}
