import tailwindcss from '@tailwindcss/vite'
import type { LocaleObject } from '@nuxtjs/i18n'
import {
  languages,
  defaultLanguage,
  type Language,
} from './app/utils/shared/language/language.types'

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },
  modules: ['@nuxt/eslint', '@nuxt/fonts', '@nuxtjs/i18n'],
  // eslint: {
  // 	config: {
  // 		stylistic: {
  // 			indent: 'tab',
  // 			semi: true,
  // 			// ...
  // 		}
  // 	}
  // },
  css: ['~/assets/styles/styles.css'],
  vite: {
    plugins: [tailwindcss()],
  },
  i18n: {
    defaultLocale: defaultLanguage.code,
    locales: [createLocale(languages.russian), createLocale(languages.english)],
    detectBrowserLanguage: false,
    experimental: {
      localeDetector: 'localeDetector.ts',
    },
  },
})

function createLocale(language: Language): LocaleObject<string> {
  return {
    code: language.code,
    name: language.name,
    file: `${language.code}.json`,
  }
}
