import { languages, type Language, type LanguageCode } from './language.types'

export const useLanguage = () => {
  const i18n = useI18n()
  const switchLocalePath = useSwitchLocalePath()

  return {
    createLocalizedUrl(code: LanguageCode): string {
      return switchLocalePath(code)
    },
    getCurrentLanguage(): Language {
      switch (i18n.locale.value) {
        case languages.english.code:
          return languages.english
        case languages.russian.code:
        default:
          return languages.russian
      }
    },
  }
}
