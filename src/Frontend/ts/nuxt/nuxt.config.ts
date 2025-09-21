import tailwindcss from '@tailwindcss/vite'
import { languages } from './app/utils/shared/language/language.types'

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
    defaultLocale: 'ru',
    locales: [
      {
        code: languages.russian.code,
        name: languages.russian.name,
        file: 'ru.json',
      },
      {
        code: languages.english.code,
        name: languages.english.name,
        file: 'en.json',
      },
    ],
    detectBrowserLanguage: false,
    experimental: {
      localeDetector: 'localeDetector.ts',
    },
  },
})
