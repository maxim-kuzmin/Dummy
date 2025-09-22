import { inject, Injectable } from '@angular/core';
import { Router, UrlSerializer, UrlTree } from '@angular/router';
import { PageUrlOptions } from './page-url.types';

@Injectable({
  providedIn: 'root',
})
export class PageUrlService {
  private readonly router = inject(Router);
  private readonly urlSerializer = inject(UrlSerializer);

  createUrl(options: PageUrlOptions): string {
    return this.urlSerializer.serialize(this.createUrlTree(options));
  }

  createUrlTree(options: PageUrlOptions): UrlTree {
    return this.router.createUrlTree(options.routeParams, {
      queryParams: options.queryParams,
    });
  }
}
