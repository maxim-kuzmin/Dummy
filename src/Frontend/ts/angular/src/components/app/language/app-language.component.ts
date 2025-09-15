import {
  Component,
  computed,
  effect,
  ElementRef,
  inject,
  OnDestroy,
  OnInit,
  signal,
  viewChild,
} from '@angular/core';

import { NavigationEnd, Router } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { AppLanguageService } from '~/utils/app/components/language/app-language.service';

@Component({
  selector: 'nav[app-language]',
  templateUrl: './app-language.component.html',
})
export class AppLanguage implements OnInit, OnDestroy {
  private readonly router = inject(Router);
  private readonly service = inject(AppLanguageService);

  private readonly isMenuOpen = signal(false);
  private readonly routerEvents = toSignal(this.router.events);

  private readonly currentUrl = computed(() => {
    const routerEvent = this.routerEvents();

    return routerEvent && routerEvent instanceof NavigationEnd
      ? routerEvent.url
      : '/';
  });

  private readonly buttonViewChild =
    viewChild<ElementRef<HTMLButtonElement>>('button');

  private readonly menuViewChild =
    viewChild<ElementRef<HTMLUListElement>>('menu');

  protected readonly data = this.service.componentData;

  protected readonly menuStyle = computed(() => ({
    visibility: this.isMenuOpen() ? 'visible' : 'hidden',
  }));

  constructor() {
    this.handleWindowClick = this.handleWindowClick.bind(this);

    effect(() => {
      this.service.loadComponentData(this.currentUrl());
    });
  }

  ngOnDestroy(): void {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', this.handleWindowClick);
    }
  }

  ngOnInit(): void {
    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', this.handleWindowClick);
    }
  }

  private handleWindowClick(ev: MouseEvent): void {
    const buttonElement = this.buttonViewChild()?.nativeElement;
    const menuElement = this.menuViewChild()?.nativeElement;

    if (!buttonElement || !menuElement) {
      return;
    }

    if (ev.target === buttonElement) {
      this.isMenuOpen.set(!this.isMenuOpen());
    } else if (ev.target !== menuElement) {
      this.isMenuOpen.set(false);
    }
  }
}
