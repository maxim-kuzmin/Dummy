import type { AppNavComponentItem } from '../../app-nav-component.types'

export interface AppNavIndexComponentStoreModel {
  readonly items: Readonly<Ref<AppNavComponentItem[]>>
  load(): void
}
