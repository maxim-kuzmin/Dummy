import { AppHeaderComponentData, type AppHeaderComponentPayload } from "./app-header-component.types";

export class AppHeaderComponentService {
  private readonly data = new AppHeaderComponentData()

  get indexPageName() {
    return this.data.indexPageName;
  }

  get indexPageUrl() {
    return this.data.indexPageUrl;
  }

  load(payload: AppHeaderComponentPayload): void {
    this.data.indexPageName.value = payload.indexPageName
    this.data.indexPageUrl.value = payload.indexPageUrl
  }
}
