import { LanguageCode } from "../language/language.types";

export interface PageDataQuery {
  readonly locale: LanguageCode
}

export class PageParameter<TDefaultValue> {
  constructor(public name: string, public defaultValue: TDefaultValue){}
}
