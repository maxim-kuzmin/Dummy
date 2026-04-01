import { inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { AppFakePageStoreService } from './store/app-fake-page-store.service';
import { AppFakePageApiDataQuery } from './api/app-fake-page-api.types';
import { AppFakePageParameters } from './app-fake-page.types';

export class AppFakePageModel {
  private readonly appFakePageStoreService = inject(AppFakePageStoreService);
  private readonly languageService = inject(LanguageService);
  private readonly activatedRoute = inject(ActivatedRoute);

  private readonly routeParams = toSignal(this.activatedRoute.params, {
    requireSync: true,
  });

  private readonly queryParams = toSignal(this.activatedRoute.queryParams, {
    requireSync: true,
  });

  load(): void {
    // fetch('https://localhost:44344/api/view/page').then(function (resp) {
    //   resp.json().then(function (json) {
    //     console.log(json);
    //   })
    // })
    const dataQuery = {
      id: String(this.routeParams()[AppFakePageParameters.id.name]),
      pageNumber: Number(
        this.queryParams()[AppFakePageParameters.pageNumber.name] ??
        AppFakePageParameters.pageNumber.defaultValue
      ),
    } as AppFakePageApiDataQuery;

    const locale = this.languageService.getCurrentLanguage().code;

    this.appFakePageStoreService.load(dataQuery, { locale });
  }
}
