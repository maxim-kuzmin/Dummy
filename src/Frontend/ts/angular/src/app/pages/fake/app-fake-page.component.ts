import {
  Component,
  computed,
  effect,
  inject,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { AppFakePageService } from '#utils/pages/fake/app-fake-page.service';
import { PageParameters } from '#utils/pages/fake/app-fake-page.types';

@Component({
  selector: 'div[app-fake-page]',
  templateUrl: './app-fake-page.component.html',
})
export class AppFakePage {
  private readonly service = inject(AppFakePageService);
  private readonly activatedRoute = inject(ActivatedRoute);

  private readonly routeParams = toSignal(this.activatedRoute.params, {
    requireSync: true,
  });

  private readonly parameters = {
      id: computed(() => String(this.routeParams()['id']))
  } as PageParameters;

  protected readonly data = this.service.pageData;

  constructor() {
    effect(() => {
      this.service.loadPageData(this.parameters.id());
    });
  }
}
