import type { ResourcesModel } from "~/utils/shared/resources/resources.types"

export const useResources = (): ResourcesModel => {
  const { t } = useI18n()

  return {
    translate: t
  }
}
