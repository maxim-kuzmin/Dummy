import type { ResourcesModel } from "./resources.types"

export const useResources = (): ResourcesModel => {
  const { t } = useI18n()

  return {
    translate: t
  }
}
