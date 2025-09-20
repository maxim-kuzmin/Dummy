import { useAppFooterComponentResources } from './resources/app-footer-component-resources.composable'
import {
  AppFooterComponentData,
  type AppFooterComponentModel,
} from './app-footer-component.types'

export const useAppFooterComponent = (): AppFooterComponentModel => {
  const appFooterComponentResources = useAppFooterComponentResources()

  const data = new AppFooterComponentData()

  watchEffect(() => {
    data.title.value = appFooterComponentResources.getTitle()
  })

  return { ...data }
}
