import type { AppIndexPageApiDataOptions } from "../api/app-index-page-api.types";

export interface AppIndexPageStoreModel {
  load(dataOptions: AppIndexPageApiDataOptions): Promise<void>
}
