import {
  AppLanguageComponentData,
  type AppLanguageComponentItem,
} from './app-language-component.types'

export const useAppLanguageComponent = () => {
  const i18n = useI18n()
  const switchLocalePath = useSwitchLocalePath()

  const isMenuOpen = ref(false)

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

  const data = new AppLanguageComponentData()

  watchEffect(() => {
    const currentLocale = i18n.locales.value.find(
      (locale) => locale.code === i18n.locale.value,
    )

    data.items.value = i18n.locales.value.map(
      (locale) =>
        ({
          code: locale.code,
          name: locale.name,
          selected: locale.code === i18n.locale.value,
          url: switchLocalePath(locale.code),
        }) as AppLanguageComponentItem,
    )

    data.menuStyle.value = {
      visibility: isMenuOpen.value ? 'visible' : 'hidden',
    }

    data.title.value = currentLocale?.name ?? ''
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

  return {
    get items() {
      return data.items
    },
    get menuStyle() {
      return data.menuStyle
    },
    get title() {
      return data.title
    },
  }
}
