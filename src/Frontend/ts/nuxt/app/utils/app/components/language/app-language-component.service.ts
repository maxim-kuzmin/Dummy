import { AppLanguageComponentData, type AppLanguageComponentPayload } from "./app-language-component.types";

export class AppLanguageComponentService {
  private readonly data = new AppLanguageComponentData()

  get items() {
    return this.data.items;
  }

  get menuStyle() {
     return this.data.menuStyle;
  }

  get title() {
    return this.data.title;
  }

  load(payload: AppLanguageComponentPayload): void {
    this.data.items.value = payload.items
    this.data.menuStyle.value = payload.menuStyle
    this.data.title.value = payload.title
  }
}
