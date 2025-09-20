export class PageStoreService {
  readonly pageKey = ref('');
  readonly pageTitle = ref('');
}

const pageStoreService = new PageStoreService();

export function getPageStoreService(): PageStoreService {
  return pageStoreService;
}
