import {
  Component,
  computed,
  effect,
  inject,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { AppFakeService } from '../app-fake.service';

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

  private readonly id = computed(() => String(this.routeParams()['id']));

  protected readonly data = computed(() => this.service.pageData());

  constructor() {
    effect(() => {
      this.service.loadPageData(this.id());
    });
  }
}
