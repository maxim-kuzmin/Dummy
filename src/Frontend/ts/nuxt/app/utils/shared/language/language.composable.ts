import {
  languages,
  type Language,
  type LanguageCode,
  type LanguageModel,
} from './language.types'

export const useLanguage = (): LanguageModel => {
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
