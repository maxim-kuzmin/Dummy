import { Component, inject, OnInit } from '@angular/core';
import { PageService } from '@services/page.service';

@Component({
  selector: 'div[app-index-page]',
  templateUrl: './app-index-page.component.html',
})
export class AppIndexPage implements OnInit {
  private pageService = inject(PageService);

  ngOnInit(): void {
    this.pageService.title.set($localize`@@page.index.title`);
  }
}
