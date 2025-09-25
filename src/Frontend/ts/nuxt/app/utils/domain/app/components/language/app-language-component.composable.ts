import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { useAppLanguageComponentStore } from './store/app-language-component-store.composable'

export const useAppLanguageComponent = (): void => {
  const appLanguageComponentStoreModel = useAppLanguageComponentStore()
  const languageModel = useLanguage()

  const isMenuOpen = ref(false)

  const languageCode = computed(() => languageModel.getCurrentLanguage().code)

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

  watch(
    [isMenuOpen, languageCode],
    () => {
      appLanguageComponentStoreModel.load({ isMenuOpen: isMenuOpen.value })
    },
    { immediate: true },
  )

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
}
