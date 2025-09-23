import type { UrlOptions } from '~/utils/infrastructure/page/url/page-url.types'
import type { LanguageCode } from '~/utils/shared/language/language.types'

export class AppIndexPageService {
  createPageKey(languageCode: LanguageCode): string {
    return `Index:${languageCode}`
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
