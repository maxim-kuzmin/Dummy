export interface AppNavComponentItem {
  children: AppNavComponentItem[];
  key: string;
  selected: boolean;
  text: string;
  url: string;
}

export interface AppNavComponentModel {
  readonly items: globalThis.Ref<AppNavComponentItem[]>
}
