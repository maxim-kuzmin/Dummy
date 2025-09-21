import type { UrlOptions } from "./url.types"

export const useUrl = (options: UrlOptions): string => {
  const localePath = useLocalePath()

  return localePath({
      name: options.routeName,
      params: options.routeParams,
      query: options.queryParams,
    })
}
