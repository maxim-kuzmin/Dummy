export class PageService {
  readonly key = ref('');
  readonly title = ref('');
}

const pageService = new PageService();

export function getPageService(): PageService {
  return pageService;
}
