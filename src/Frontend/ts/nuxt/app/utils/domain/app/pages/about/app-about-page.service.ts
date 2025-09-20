import type { PageUrlOptions } from '~/utils/infrastructure/page/url/page-url.types'

export class AppAboutPageService {
  createPageKey(): string {
    return 'About'
  }

  createPageUrlOptions(): PageUrlOptions {
    return {
      routeName: 'about',
    }
  }
}

const appAboutPageService = new AppAboutPageService()

export function getAppAboutPageService(): AppAboutPageService {
  return appAboutPageService
}
