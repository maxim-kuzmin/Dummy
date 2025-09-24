import type { AppNavComponentItem } from "../../app-nav-component.types";

export interface AppNavIndexComponentStoreData {
  readonly items: Readonly<Ref<AppNavComponentItem[]>>
}

export interface AppNavIndexComponentStoreModel extends AppNavIndexComponentStoreData {
  load(): void
}
