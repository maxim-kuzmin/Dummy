import { inject, Injectable } from '@angular/core';
import { Router, UrlSerializer, UrlTree } from '@angular/router';
import { UrlOptions } from './url.types';

@Injectable({
  providedIn: 'root',
})
export class UrlService {
  private readonly router = inject(Router);
  private readonly urlSerializer = inject(UrlSerializer);

  createUrl(options: UrlOptions): string {
    return this.urlSerializer.serialize(this.createUrlTree(options));
  }

  createUrlTree(options: UrlOptions): UrlTree {
    return this.router.createUrlTree(options.routeParams, {
      queryParams: options.queryParams,
    });
  }
}
