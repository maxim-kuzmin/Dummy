export type LanguageCode = 'ru' | 'en'

export class Language {
  constructor(
    public code: LanguageCode,
    public name: string,
  ) {}
}

export const languages = {
  english: new Language('en', 'English'),
  russian: new Language('ru', 'Русский'),
}
