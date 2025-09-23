import type { LanguageCode } from "~/utils/shared/language/language.types"

export class AppNotFoundPageService {
  createPageKey(languageCode: LanguageCode): string {
    return `NotFound:${languageCode}`
  }
}

const appNotFoundPageService = new AppNotFoundPageService()

export function getAppNotFoundPageService(): AppNotFoundPageService {
  return appNotFoundPageService
}
