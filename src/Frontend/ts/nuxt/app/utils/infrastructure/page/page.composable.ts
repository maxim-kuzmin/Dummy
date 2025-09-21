import type { PageModel } from "./page.types"

const storeKey = 'page'

export const usePage = (): PageModel => {
  const pageKey = useState(`${storeKey}.pageKey`, () => '')
  const pageTitle = useState(`${storeKey}.pageTitle`, () => '')

  return { pageKey, pageTitle }
}
