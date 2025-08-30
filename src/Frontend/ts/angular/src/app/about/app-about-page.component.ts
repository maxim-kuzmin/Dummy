import { Component, inject, OnInit } from '@angular/core';
import { PageService } from '@services/page.service';

@Component({
  selector: 'div[app-about-page]',
  templateUrl: './app-about-page.component.html',
})
export class AppAboutPage implements OnInit {
  private pageService = inject(PageService);

  ngOnInit(): void {
    this.pageService.title.set($localize`@@page.about.title`);
  }
}
