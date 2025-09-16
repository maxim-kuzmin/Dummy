import type { CSSProperties } from 'vue'

export interface AppLanguageComponentItem {
  code: 'ru' | 'en'
  name: string
  selected: boolean
  url: string
}

export interface AppLanguageComponentPayload {
  readonly items: AppLanguageComponentItem[]
  readonly menuStyle: CSSProperties
  readonly title: string
}

export class AppLanguageComponentData {
  readonly items = ref<AppLanguageComponentItem[]>([])
  readonly menuStyle = ref<CSSProperties>({ visibility: 'hidden' })
  readonly title = ref('')
}
