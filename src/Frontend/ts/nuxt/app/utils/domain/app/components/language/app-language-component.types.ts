import type { CSSProperties } from 'vue'

export interface AppLanguageComponentItem {
  code: 'ru' | 'en'
  name: string
  selected: boolean
  url: string
}

export interface AppLanguageComponentModel {
  readonly items: globalThis.Ref<AppLanguageComponentItem[]>
  readonly menuStyle: globalThis.Ref<CSSProperties>
  readonly title: globalThis.Ref<string>
}
