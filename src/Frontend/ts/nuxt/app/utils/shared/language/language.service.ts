import  {type LanguageCode, defaultLanguage } from './language.types'

export class LanguageService {
  getLanguageCodeByPath(path: string): LanguageCode {
    let result = this.getLanguageCode(path, 'en')

    if (!result) {
      result = defaultLanguage.code
    }

    return result
  }

  private getLanguageCode(path: string, code: LanguageCode): LanguageCode | null {
    if (path.endsWith(`/${code}`) || path.startsWith(`/${code}/`)) {
      return code
    }

    return null
  }
}

const languageService = new LanguageService()

export function getLanguageService() {
  return languageService
}
