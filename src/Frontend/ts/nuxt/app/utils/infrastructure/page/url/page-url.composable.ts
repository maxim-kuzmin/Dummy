import type { UrlOptions } from "./page-url.types"

export const usePageUrl = (options: UrlOptions): string => {
  const localePath = useLocalePath()

  return localePath({
      name: options.routeName,
      params: options.routeParams,
      query: options.queryParams,
    })
}
