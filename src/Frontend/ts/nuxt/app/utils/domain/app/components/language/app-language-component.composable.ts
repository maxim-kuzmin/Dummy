import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { languages } from '~/utils/shared/language/language.types'
import {
  AppLanguageComponentData,
  type AppLanguageComponentItem,
  type AppLanguageComponentModel,
} from './app-language-component.types'

export const useAppLanguageComponent = (): AppLanguageComponentModel => {
  const languageModel = useLanguage()

  const isMenuOpen = ref(false)

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

  const data = new AppLanguageComponentData()

  watchEffect(() => {
    const currentLanguage = languageModel.getCurrentLanguage()

    data.items.value = [languages.russian, languages.english].map(
      (language) =>
        ({
          code: language.code,
          name: language.name,
          selected: language.code === currentLanguage.code,
          url: languageModel.createLocalizedUrl(language.code),
        }) as AppLanguageComponentItem,
    )

    data.menuStyle.value = {
      visibility: isMenuOpen.value ? 'visible' : 'hidden',
    }

    data.title.value = currentLanguage.name
  })

  onMounted(() => {
    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', handleWindowClick)
    }
  })

  onUnmounted(() => {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', handleWindowClick)
    }
  })

  function handleWindowClick(ev: MouseEvent): void {
    const buttonElement = buttonElementRef.value
    const menuElement = menuElementRef.value

    if (!buttonElement || !menuElement) {
      return
    }

    if (ev.target === buttonElement) {
      isMenuOpen.value = !isMenuOpen.value
    } else if (ev.target !== menuElement) {
      isMenuOpen.value = false
    }
  }

  return { ...data }
}
