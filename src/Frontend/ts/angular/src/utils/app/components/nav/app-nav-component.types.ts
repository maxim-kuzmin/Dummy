export interface AppNavComponentItem {
  children: AppNavComponentItem[];
  key: string;
  selected: boolean;
  text: string;
  url: string;
}
