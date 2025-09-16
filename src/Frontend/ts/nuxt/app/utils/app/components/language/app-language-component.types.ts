import type { CSSProperties } from "vue"

export interface AppLanguageComponentItem {
  code: 'ru' | 'en'
  name: string
  url: string
  selected: boolean
}

export interface AppLanguageComponentData {
  readonly currentLanguageName: globalThis.Ref<string>
  readonly items: globalThis.Ref<AppLanguageComponentItem[]>
  readonly menuStyle: globalThis.Ref<CSSProperties>
}

export class AppLanguageComponentData1 {
  readonly currentLanguageName = ref('')
  readonly items = ref<AppLanguageComponentItem[]>([])
  readonly menuStyle = ref<CSSProperties>({})
}
