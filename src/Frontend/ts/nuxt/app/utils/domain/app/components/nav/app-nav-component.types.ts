export class AppNavComponentData {
  readonly items = ref<AppNavComponentItem[]>([])
}

export interface AppNavComponentItem {
  children: AppNavComponentItem[];
  key: string;
  selected: boolean;
  text: string;
  url: string;
}

export type AppNavComponentModel = AppNavComponentData
