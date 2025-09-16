import { AppMainComponentData, type AppMainComponentPayload } from './app-main-component.types'

export class AppMainComponentService {
  private readonly data = new AppMainComponentData()

  get title() {
    return this.data.title
  }

  load(payload: AppMainComponentPayload) {
    this.data.title.value = payload.title
  }
}
