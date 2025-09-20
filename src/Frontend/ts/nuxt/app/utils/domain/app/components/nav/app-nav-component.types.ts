export class AppNavComponentData {
  readonly aboutPageUrl = ref('')
  readonly fakePageUrl1 = ref('')
  readonly fakePageUrl1pn2 = ref('')
  readonly fakePageUrl2 = ref('')
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
