import type { LanguageCode } from "../language/language.types"

export interface PageData {
  readonly pageKey: string
  readonly pageTitle: string
}

export interface PageDataQuery {
  readonly locale: LanguageCode
}

export class PageParameter<TDefaultValue> {
  constructor(public name: string, public defaultValue: TDefaultValue){}
}
