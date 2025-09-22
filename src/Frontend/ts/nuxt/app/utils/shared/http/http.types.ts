import type { LanguageCode } from "../language/language.types";

export const HttpCookieNames = {
  locale: 'i18n_locale'
} as const

export const HttpHeaderNames = {
  locale: 'locale'
} as const

export const HttpParameterNames = {
  id: 'id',
  locale: 'locale',
  pageNumber: 'pn',
} as const;

export interface HttpRequestOptions {
  locale: LanguageCode
}
