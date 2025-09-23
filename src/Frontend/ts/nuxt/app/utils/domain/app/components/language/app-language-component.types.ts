import type { LanguageCode } from '~/utils/shared/language/language.types'
import type { AppLanguageComponentStoreData } from './store/app-language-component-store.types'

export interface AppLanguageComponentItem {
  code: LanguageCode
  name: string
  selected: boolean
  url: string
}

export type AppLanguageComponentModel = AppLanguageComponentStoreData
