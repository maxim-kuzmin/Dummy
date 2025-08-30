import { Component, inject, signal } from '@angular/core';
import { PageService } from '~shared/page/page.service';

@Component({
  selector: 'main[app-main]',
  templateUrl: './app-main.component.html',
})
export class AppMain {
  pageService = inject(PageService);
}
