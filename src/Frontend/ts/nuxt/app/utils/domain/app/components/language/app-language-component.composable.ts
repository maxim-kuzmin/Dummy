import type { AppLanguageComponentModel } from './app-language-component.types'
import { useAppLanguageComponentStore } from './store/app-language-component-store.composable'

export const useAppLanguageComponent = (): AppLanguageComponentModel => {
  const appLanguageComponentStoreModel = useAppLanguageComponentStore()

  const isMenuOpen = ref(false)

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

  watchEffect(() => {
    appLanguageComponentStoreModel.load(isMenuOpen.value)
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

  return { ...appLanguageComponentStoreModel }
}
