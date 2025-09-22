import type { UrlOptions } from '~/utils/infrastructure/page/url/page-url.types'

export class AppAboutPageService {
  createPageKey(): string {
    return 'About'
  }

  createPageUrlOptions(): UrlOptions {
    return {
      routeName: 'about',
    }
  }
}

const appAboutPageService = new AppAboutPageService()

export function getAppAboutPageService(): AppAboutPageService {
  return appAboutPageService
}
