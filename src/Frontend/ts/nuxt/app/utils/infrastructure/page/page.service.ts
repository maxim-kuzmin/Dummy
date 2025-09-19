export class PageService {
  readonly key = ref('');
  readonly title = ref('');
}

const instanceOfPageService = new PageService();

export function getPageService(): PageService {
  return instanceOfPageService;
}
