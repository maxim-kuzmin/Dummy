import type { UrlOptions } from '~/utils/infrastructure/page/url/page-url.types'
import type { LanguageCode } from '~/utils/shared/language/language.types'

export class AppAboutPageService {
  createPageKey(languageCode: LanguageCode): string {
    return `About:${languageCode}`
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
