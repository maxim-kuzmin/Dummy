import { getPageService } from "~/utils/shared/page/page.service";

export class AppAboutPageService {
  private readonly pageService = getPageService();

  createPageKey(): string {
    return 'About';
  }

  createPageUrl(): string {
    return '/about';
  }

  loadPageData() {
    this.pageService.key.value = this.createPageKey();

    this.pageService.title.value = 'page.about.title';
  }
}
