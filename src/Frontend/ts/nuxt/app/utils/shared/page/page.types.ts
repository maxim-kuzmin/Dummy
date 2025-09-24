export interface PageData {
  get pageTitle(): string
}

export class PageParameter<TDefaultValue> {
  constructor(public name: string, public defaultValue: TDefaultValue){}
}
