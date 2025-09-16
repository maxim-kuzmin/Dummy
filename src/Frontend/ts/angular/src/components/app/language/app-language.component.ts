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

import { AppLanguageComponentService } from '~/utils/app/components/language/app-language-component.service';

@Component({
  selector: 'nav[app-language]',
  templateUrl: './app-language.component.html',
})
export class AppLanguage implements OnInit, OnDestroy, AfterViewInit {
  private readonly service = inject(AppLanguageComponentService);

  private readonly buttonElementRef =
    viewChild<ElementRef<HTMLButtonElement>>('button');

  private readonly menuElementRef =
    viewChild<ElementRef<HTMLUListElement>>('menu');

  protected get items() {
    return this.service.items();
  }

  protected get menuStyle() {
    return this.service.menuStyle();
  }

  protected get title() {
    return this.service.title;
  }

  constructor() {
    effect(() => {
      this.service.load();
    });
  }

  ngAfterViewInit(): void {
    this.service.initView(this.buttonElementRef, this.menuElementRef);
  }

  ngOnDestroy(): void {
    this.service.destroy();
  }

  ngOnInit(): void {
    this.service.init();
  }
}
