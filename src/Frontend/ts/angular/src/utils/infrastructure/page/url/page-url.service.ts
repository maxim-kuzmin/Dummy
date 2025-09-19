import { inject, Injectable } from '@angular/core';
import { Router, UrlSerializer, UrlTree } from '@angular/router';
import { PageUrlOptions } from './page-url.types';

@Injectable({
  providedIn: 'root',
})
export class PageUrlService {
  private readonly router = inject(Router);
  private readonly urlSerializer = inject(UrlSerializer);

  createPageUrl(options: PageUrlOptions): string {
    return this.urlSerializer.serialize(this.createPageUrlTree(options));
  }

  createPageUrlTree(options: PageUrlOptions): UrlTree {
    return this.router.createUrlTree(options.routeParams, {
      queryParams: options.queryParams,
    });
  }
}
