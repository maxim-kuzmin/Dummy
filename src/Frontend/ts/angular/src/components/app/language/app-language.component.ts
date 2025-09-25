import {
  AfterViewInit,
  Component,
  effect,
  ElementRef,
  inject,
  OnDestroy,
  OnInit,
  viewChild,
} from '@angular/core';

import { AppLanguageComponentModel } from '~/utils/domain/app/components/language/app-language-component.model';
import {
  AppLanguageComponentItem,
  AppLanguageComponentMenuStyle,
} from '~/utils/domain/app/components/language/app-language-component.types';
import { AppLanguageComponentStoreService } from '~/utils/domain/app/components/language/store/app-language-component-store.service';

@Component({
  selector: 'nav[app-language]',
  templateUrl: './app-language.component.html',
  providers: [AppLanguageComponentModel],
})
export class AppLanguage implements OnInit, OnDestroy, AfterViewInit {
  private readonly appLanguageComponentModel = inject(
    AppLanguageComponentModel,
    { self: true }
  );
  private readonly appLanguageComponentStoreService = inject(
    AppLanguageComponentStoreService
  );

  private readonly buttonElementRef =
    viewChild<ElementRef<HTMLButtonElement>>('button');

  private readonly menuElementRef =
    viewChild<ElementRef<HTMLUListElement>>('menu');

  protected get items(): AppLanguageComponentItem[] {
    return this.appLanguageComponentStoreService.items();
  }

  protected get menuStyle(): AppLanguageComponentMenuStyle {
    return this.appLanguageComponentStoreService.menuStyle();
  }

  protected get title(): string {
    return this.appLanguageComponentStoreService.title();
  }

  constructor() {
    effect(() => {
      this.appLanguageComponentModel.load();
    });
  }

  ngAfterViewInit(): void {
    this.appLanguageComponentModel.initView(
      this.buttonElementRef,
      this.menuElementRef
    );
  }

  ngOnDestroy(): void {
    this.appLanguageComponentModel.destroy();
  }

  ngOnInit(): void {
    this.appLanguageComponentModel.init();
  }
}
