export interface PageData {
  readonly pageTitle: string;
}

export class PageParameter<TDefaultValue> {
  constructor(public name: string, public defaultValue: TDefaultValue) {}
}
