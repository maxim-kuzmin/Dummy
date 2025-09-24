import type { CSSProperties } from 'vue'
import type { AppLanguageComponentItem } from '../app-language-component.types'

export interface AppLanguageComponentStoreData {
  readonly items: Readonly<Ref<AppLanguageComponentItem[]>>
  readonly menuStyle: Readonly<Ref<CSSProperties>>
  readonly title: Readonly<Ref<string>>
}

export interface AppLanguageComponentStoreDataQuery {
  readonly isMenuOpen: boolean
}

export interface AppLanguageComponentStoreModel
  extends AppLanguageComponentStoreData {
  load(dataQuery: AppLanguageComponentStoreDataQuery): void
}
