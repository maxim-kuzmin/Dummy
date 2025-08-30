import tailwindcss from '@tailwindcss/vite'

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
	compatibilityDate: '2025-07-15',
	devtools: { enabled: true },
	modules: ['@nuxt/eslint', '@nuxt/fonts'],
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
})
