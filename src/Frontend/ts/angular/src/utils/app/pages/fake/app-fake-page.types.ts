import { Signal } from "@angular/core";

export interface AppFakePageData {
  readonly key: Signal<string>;
}

export interface AppFakePageParameters {
  readonly id: Signal<string>;
}

export interface AppFakePageRouteParams {
  id: string;
}
