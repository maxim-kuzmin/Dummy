import { Signal } from "@angular/core";

export interface PageData {
  readonly key: Signal<string>;
}

export interface PageParameters {
  readonly id: Signal<string>;
}

export interface PageRouteParams {
  id: string;
}
