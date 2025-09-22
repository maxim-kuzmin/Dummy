export interface AppFakePageStoreModel {
  readonly clickCount: globalThis.Ref<number>
  readonly pageKey: globalThis.Ref<string>
  click(): void
  load(): void
}
