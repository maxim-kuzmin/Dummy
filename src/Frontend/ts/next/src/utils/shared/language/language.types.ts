export type LanguageCode = 'ru' | 'en';

export class Language {
  constructor(
    public code: LanguageCode,
    public name: string,
  ) {}
}

export interface LanguageModel {
  createLocalizedUrl(code: LanguageCode): string;
  getCurrentLanguage(): Language;
}

export const languages = {
  english: new Language('en', 'English'),
  russian: new Language('ru', 'Русский'),
};

export const defaultLanguage = languages.russian;
