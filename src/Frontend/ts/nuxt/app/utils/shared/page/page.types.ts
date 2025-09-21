export interface PageData {
  readonly pageKey: string
  readonly pageTitle: string
}

export class PageParameter<TDefaultValue> {
  constructor(public name: string, public defaultValue: TDefaultValue){}
}
