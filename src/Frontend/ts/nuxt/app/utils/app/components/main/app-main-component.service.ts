import { getPageService } from '~/utils/shared/page/page.service'

export class AppMainComponentService {
  private readonly pageService = getPageService()

  readonly title = this.pageService.title
}

const instanceOfAppMainComponentService = new AppMainComponentService()

export function getAppMainComponentService(): AppMainComponentService {
  return instanceOfAppMainComponentService
}
