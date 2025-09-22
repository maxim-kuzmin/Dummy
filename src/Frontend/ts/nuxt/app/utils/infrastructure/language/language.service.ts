import type { EventHandlerRequest, H3Event } from 'h3'
import {
  HttpCookieNames,
  HttpHeaderNames,
  HttpParameterNames,
} from '~/utils/shared/http/http.types'
import {
  defaultLanguage,
  languages,
  type LanguageCode,
} from '~/utils/shared/language/language.types'

export class LanguageService {
  getLanguageCodeFromH3Event(
    event: H3Event<EventHandlerRequest>,
  ): LanguageCode {
    const query = tryQueryLocale(event, {
      lang: '',
      name: HttpParameterNames.locale,
    })

    if (query) {
      return query.toString() as LanguageCode
    }

    const cookie = tryCookieLocale(event, {
      lang: '',
      name: HttpCookieNames.locale,
    })

    if (cookie) {
      return cookie.toString() as LanguageCode
    }

    const header = getRequestHeader(event, HttpHeaderNames.locale)

    if (header) {
      return header.toString() as LanguageCode
    }

    return defaultLanguage.code
  }

  getLanguageCodeFromPath(path: string): LanguageCode {
    const englishLanguageCode = this.getLanguageCode(
      path,
      languages.english.code,
    )

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
