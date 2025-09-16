import {
  AppNavComponentData,
  type AppNavComponentPayload,
} from './app-nav-component.types'

export class AppNavComponentService {
  private readonly data = new AppNavComponentData()

  get aboutPageUrl() {
    return this.data.aboutPageUrl
  }

  get fakePageUrl1() {
    return this.data.fakePageUrl1
  }

  get fakePageUrl1pn2() {
    return this.data.fakePageUrl1pn2
  }

  get fakePageUrl2() {
    return this.data.fakePageUrl2
  }

  load(payload: AppNavComponentPayload) {
    this.data.aboutPageUrl.value = payload.aboutPageUrl
    this.data.fakePageUrl1.value = payload.fakePageUrl1
    this.data.fakePageUrl1pn2.value = payload.fakePageUrl1pn2
    this.data.fakePageUrl2.value = payload.fakePageUrl2
  }
}
