import { AppLanguageComponentService } from './app-language-component.service'
import type {
  AppLanguageComponentItem,
  AppLanguageComponentPayload,
} from './app-language-component.types'

export const useAppLanguageComponentService = () => {
  const result = new AppLanguageComponentService()

  const i18n = useI18n()
  const switchLocalePath = useSwitchLocalePath()

  const isMenuOpen = ref(false)

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

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

  watchEffect(() => {
    const currentLocale = i18n.locales.value.find(
      (locale) => locale.code === i18n.locale.value,
    )

    const payload = {
      items: i18n.locales.value.map(
        (locale) =>
          ({
            code: locale.code,
            name: locale.name,
            selected: locale.code === i18n.locale.value,
            url: switchLocalePath(locale.code),
          }) as AppLanguageComponentItem,
      ),
      menuStyle: {
        visibility: isMenuOpen.value ? 'visible' : 'hidden',
      },
      title: currentLocale?.name ?? '',
    } as AppLanguageComponentPayload

    result.load(payload)
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

  return result
}
