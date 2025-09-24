import type { CSSProperties } from 'vue'
import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { languages } from '~/utils/shared/language/language.types'
import type { AppLanguageComponentItem } from '../app-language-component.types'
import type { AppLanguageComponentStoreModel } from './app-language-component-store.types'

const storeKey = 'app-language-component'

export const useAppLanguageComponentStore =
  (): AppLanguageComponentStoreModel => {
    const languageModel = useLanguage()

    const items = useState<AppLanguageComponentItem[]>(
      `${storeKey}.items`,
      () => [],
    )

    const menuStyle = useState<CSSProperties>(`${storeKey}.menuStyle`, () => ({
      visibility: 'hidden',
    }))

    const title = useState(`${storeKey}.title`, () => '')

    return {
      items: readonly(items) as Readonly<Ref<AppLanguageComponentItem[]>>,
      menuStyle: readonly(menuStyle),
      title: readonly(title),
      load(isMenuOpen: boolean): void {
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
          visibility: isMenuOpen ? 'visible' : 'hidden',
        }

        title.value = currentLanguage.name
      },
    }
  }
