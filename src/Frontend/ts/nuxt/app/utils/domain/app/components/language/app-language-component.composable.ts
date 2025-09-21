import type { CSSProperties } from 'vue'
import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { languages } from '~/utils/shared/language/language.types'
import type {
  AppLanguageComponentItem,
  AppLanguageComponentModel,
} from './app-language-component.types'

const storeKey = 'app-language-component'

export const useAppLanguageComponent = (): AppLanguageComponentModel => {
  const languageModel = useLanguage()

  const isMenuOpen = ref(false)

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

  const items = useState<AppLanguageComponentItem[]>(
    `${storeKey}.items`,
    () => [],
  )

  const menuStyle = useState<CSSProperties>(`${storeKey}.menuStyle`, () => ({
    visibility: 'hidden',
  }))

  const title = useState(`${storeKey}.title`, () => '')

  watchEffect(load)

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

  function load() {
    const currentLanguage = languageModel.getCurrentLanguage()

    items.value = [languages.russian, languages.english].map(
      (language) =>
        ({
          code: language.code,
          name: language.name,
          selected: language.code === currentLanguage.code,
          url: languageModel.createLocalizedUrl(language.code),
        }) as AppLanguageComponentItem,
    )

    menuStyle.value = {
      visibility: isMenuOpen.value ? 'visible' : 'hidden',
    }

    title.value = currentLanguage.name
  }

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

  return { items, menuStyle, title }
}
