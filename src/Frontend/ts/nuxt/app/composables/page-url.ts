import type { PageUrlOptions } from "~/utils/shared/page/page.types"

export const usePageUrl = (options: PageUrlOptions) => {
  const localePath = useLocalePath()

  const result = computed(() => localePath({
      name: options.routeName,
      params: options.routeParams,
      query: options.locationQuery,
    }))
  return result
}
