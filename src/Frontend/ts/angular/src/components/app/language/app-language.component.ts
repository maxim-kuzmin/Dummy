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

@Component({
  selector: 'nav[app-language]',
  templateUrl: './app-language.component.html',
  providers: [AppLanguageComponentModel],
})
export class AppLanguage implements OnInit, OnDestroy, AfterViewInit {
  private readonly model = inject(AppLanguageComponentModel, { self: true });

  private readonly buttonElementRef =
    viewChild<ElementRef<HTMLButtonElement>>('button');

  private readonly menuElementRef =
    viewChild<ElementRef<HTMLUListElement>>('menu');

  protected get items() {
    return this.model.items();
  }

  protected get menuStyle() {
    return this.model.menuStyle();
  }

  protected get title() {
    return this.model.title;
  }

  constructor() {
    effect(() => {
      this.model.load();
    });
  }

  ngAfterViewInit(): void {
    this.model.initView(this.buttonElementRef, this.menuElementRef);
  }

  ngOnDestroy(): void {
    this.model.destroy();
  }

  ngOnInit(): void {
    this.model.init();
  }
}
