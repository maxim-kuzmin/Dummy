import type { ResourcesModel } from '~/utils/shared/resources/resources.types'

export const useClientResources = (): ResourcesModel => {
  const { t } = useI18n()

  return {
    translate: t,
  }
}
