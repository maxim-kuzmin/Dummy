export interface ComponentData {
  items: Item[];
}

export interface Item {
  key: string;
  url: string;
  text: string;
  children: Item[];
  selected: boolean;
}
