export class AppMainComponentData {
  readonly title = ref('')
}

export type AppMainComponentModel = AppMainComponentData & {
  refresh(): void
}
