export class AppNotFoundPageService {
  createPageKey(): string {
    return 'NotFound'
  }
}

const appNotFoundPageService = new AppNotFoundPageService()

export function getAppNotFoundPageService(): AppNotFoundPageService {
  return appNotFoundPageService
}
