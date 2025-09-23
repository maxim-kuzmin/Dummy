import type { AppNavComponentItem } from "../../app-nav-component.types";

export interface AppNavIndexComponentStoreData {
  readonly items: globalThis.Ref<AppNavComponentItem[]>
}

export interface AppNavIndexComponentStoreModel extends AppNavIndexComponentStoreData {
  load(): void
}
