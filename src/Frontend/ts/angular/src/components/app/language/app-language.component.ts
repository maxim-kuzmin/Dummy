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

  protected readonly data = this.service.data;

  constructor() {
    effect(() => {
      this.service.load();
    });
  }

  ngAfterViewInit(): void {
    this.service.onAfterViewInit(this.buttonElementRef, this.menuElementRef);
  }

  ngOnDestroy(): void {
    this.service.onDestroy();
  }

  ngOnInit(): void {
    this.service.onInit();
  }
}
