import { getLanguageService } from "~/utils/infrastructure/language/language.service"

export default defineI18nLocaleDetector((event) => {
  const languageService = getLanguageService()

  return languageService.getLanguageCodeFromH3Event(event)
})
