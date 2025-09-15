import type { CSSProperties } from "vue"

export interface AppLanguageItem {
  code: 'ru' | 'en'
  name: string
  url: string
  selected: boolean
}

export interface AppLanguageData {
  readonly currentLanguageName: globalThis.Ref<string>
  readonly items: globalThis.Ref<AppLanguageItem[]>
  readonly menuStyle: globalThis.Ref<CSSProperties>
}
