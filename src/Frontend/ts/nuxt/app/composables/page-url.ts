import type { PageUrlOptions } from "~/utils/shared/page/page.types"

export const usePageUrl = (options: PageUrlOptions) => {
  const localePath = useLocalePath()

  const result = computed(() => localePath({
      name: options.routeName,
      params: options.routeParams,
    }))
  return result
}
