import { Component, computed, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageService } from '~shared/page/page.service';
import { PageKeyEnum } from '~shared/page/page.types';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'div[app-fake-page]',
  templateUrl: './app-fake-page.component.html',
})
export class AppFakePage {
  private readonly pageService = inject(PageService);
  private readonly activatedRoute = inject(ActivatedRoute);

  private readonly routeParams = toSignal(this.activatedRoute.params, {
    requireSync: true,
  });

  protected readonly id = computed(() => this.routeParams()['id']);

  constructor() {
    this.pageService.title.set($localize`:@@page.fake.title:@@`);
    this.pageService.key.set(PageKeyEnum.Fake);
  }
}
