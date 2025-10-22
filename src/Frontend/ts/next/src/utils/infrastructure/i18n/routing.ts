import { defineRouting } from 'next-intl/routing';
import {
  languages,
  defaultLanguage,
} from '~/utils/shared/language/language.types';

export const routing = defineRouting({
  locales: [languages.russian.code, languages.english.code],
  defaultLocale: defaultLanguage.code,
  localePrefix: 'as-needed',
  localeCookie: false,
  localeDetection: false,
});
