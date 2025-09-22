import type { EventHandlerRequest, H3Event } from 'h3'
import type { ResourcesModel } from '~/utils/shared/resources/resources.types'

export const useServerResources = async (
  event: H3Event<EventHandlerRequest>,
): Promise<ResourcesModel> => {
  const t = await useTranslation(event)

  return {
    translate: t,
  }
}
