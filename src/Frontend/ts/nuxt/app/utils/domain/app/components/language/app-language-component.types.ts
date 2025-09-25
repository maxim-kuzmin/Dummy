import type { LanguageCode } from '~/utils/shared/language/language.types'

export interface AppLanguageComponentItem {
  code: LanguageCode
  name: string
  selected: boolean
  url: string
}
