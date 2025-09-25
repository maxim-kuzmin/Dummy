import type { CSSProperties } from 'vue'
import type { AppLanguageComponentItem } from '../app-language-component.types'

export interface AppLanguageComponentStoreDataQuery {
  readonly isMenuOpen: boolean
}

export interface AppLanguageComponentStoreModel {
  readonly items: Readonly<Ref<AppLanguageComponentItem[]>>
  readonly menuStyle: Readonly<Ref<CSSProperties>>
  readonly title: Readonly<Ref<string>>
  load(dataQuery: AppLanguageComponentStoreDataQuery): void
}
