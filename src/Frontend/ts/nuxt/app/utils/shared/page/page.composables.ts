import type { PageUrlOptions } from "./page.types"

export const usePageUrl = (options: PageUrlOptions) => {
  const localePath = useLocalePath()

  const result = computed(() => localePath({
      name: options.routeName,
      params: options.routeParams,
      query: options.locationQuery,
    }))
  return result
}
