export interface AppNavComponentItem {
  children: Ref<AppNavComponentItem[]>;
  key: string;
  selected: Ref<boolean>;
  text: Ref<string>;
  url: Ref<string>;
}
