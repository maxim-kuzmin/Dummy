import { getPageService } from '~/utils/shared/page/page.service'

export class AppMainService {
  private readonly pageService = getPageService()

  readonly title = this.pageService.title
}

const instanceOfAppMainService = new AppMainService()

export function getAppMainService(): AppMainService {
  return instanceOfAppMainService
}
