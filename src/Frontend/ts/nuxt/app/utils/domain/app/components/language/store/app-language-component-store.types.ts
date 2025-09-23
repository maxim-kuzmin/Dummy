import type { CSSProperties } from 'vue'
import type { AppLanguageComponentItem } from '../app-language-component.types'

export interface AppLanguageComponentStoreData {
  readonly items: globalThis.Ref<AppLanguageComponentItem[]>
  readonly menuStyle: globalThis.Ref<CSSProperties>
  readonly title: globalThis.Ref<string>
}

export interface AppLanguageComponentStoreModel
  extends AppLanguageComponentStoreData {
  load(isMenuOpen: boolean): void
}
