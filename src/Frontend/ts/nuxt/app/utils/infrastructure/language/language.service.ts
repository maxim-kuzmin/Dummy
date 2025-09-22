import type { EventHandlerRequest, H3Event } from 'h3'
import {
  defaultLanguage,
  languages,
  type LanguageCode,
} from '~/utils/shared/language/language.types'

export class LanguageService {
  getLanguageCodeFromH3Event(event: H3Event<EventHandlerRequest>): LanguageCode {
    const query = tryQueryLocale(event, { lang: '', name: 'locale' })

    if (query) {
      return query.toString() as LanguageCode
    }

    const cookie = tryCookieLocale(event, { lang: '', name: 'i18n_locale' })

    if (cookie) {
      return cookie.toString() as LanguageCode
    }

    const header = tryHeaderLocale(event, { lang: '', name: 'Accept-Language' })

    if (header) {
      return header.toString() as LanguageCode
    }

    return defaultLanguage.code
  }

  getLanguageCodeFromPath(path: string): LanguageCode {
    const englishLanguageCode = this.getLanguageCode(path, languages.english.code)

    if (englishLanguageCode) {
      return englishLanguageCode
    }

    return defaultLanguage.code
  }

  private getLanguageCode(
    path: string,
    code: LanguageCode,
  ): LanguageCode | null {
    if (path.endsWith(`/${code}`) || path.startsWith(`/${code}/`)) {
      return code
    }

    return null
  }
}

const languageService = new LanguageService()

export function getLanguageService() {
  return languageService
}
