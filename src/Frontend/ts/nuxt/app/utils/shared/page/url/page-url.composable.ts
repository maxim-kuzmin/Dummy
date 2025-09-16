import type { PageUrlOptions } from "./page-url.types"

export const usePageUrl = (options: PageUrlOptions) => {
  const localePath = useLocalePath()

  return localePath({
      name: options.routeName,
      params: options.routeParams,
      query: options.locationQuery,
    })
}
