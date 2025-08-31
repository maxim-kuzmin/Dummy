import {
  Component,
  computed,
  effect,
  inject,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { AppFakeService } from '../app-fake.service';
import { PageParameters } from '../app-fake.types';

@Component({
  selector: 'div[app-fake-page]',
  templateUrl: './app-fake-page.component.html',
})
export class AppFakePage {
  private readonly service = inject(AppFakeService);
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
