import { computed, ElementRef, inject, Signal, signal } from '@angular/core';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { AppLanguageComponentItem } from './app-language-component.types';
import { NavigationEnd, Router } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { languages } from '~/utils/shared/language/language.types';

export class AppLanguageComponentModel {
  private readonly languageService = inject(LanguageService);
  private readonly router = inject(Router);

  private readonly isMenuOpen = signal(false);

  private readonly routerEvents = toSignal(this.router.events);

  private buttonElementRef!: Signal<ElementRef<HTMLButtonElement> | undefined>;
  private menuElementRef!: Signal<ElementRef<HTMLUListElement> | undefined>;

  private readonly currentUrl = computed(() => {
    const routerEvent = this.routerEvents();

    return routerEvent && routerEvent instanceof NavigationEnd
      ? routerEvent.url
      : '/';
  });

  readonly items = signal<AppLanguageComponentItem[]>([]);
  readonly menuStyle = signal({ visibility: 'hidden' });
  title = '';

  constructor() {
    this.handleWindowClick = this.handleWindowClick.bind(this);
  }

  destroy(): void {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', this.handleWindowClick);
    }
  }

  init(): void {
    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', this.handleWindowClick);
    }
  }

  initView(
    buttonElementRef: Signal<ElementRef<HTMLButtonElement> | undefined>,
    menuElementRef: Signal<ElementRef<HTMLUListElement> | undefined>
  ): void {
    this.buttonElementRef = buttonElementRef;
    this.menuElementRef = menuElementRef;
  }

  load(): void {
    const currentLanguage = this.languageService.getCurrentLanguage();
    const currentUrl = this.currentUrl();

    this.items.set(
      [languages.russian, languages.english].map(
        (language) =>
          ({
            code: language.code,
            name: language.name,
            selected: language.code === currentLanguage.code,
            url: this.languageService.createLocalizedUrl(
              language.code,
              currentUrl
            ),
          } as AppLanguageComponentItem)
      )
    );

    this.menuStyle.set({
      visibility: this.isMenuOpen() ? 'visible' : 'hidden',
    });

    this.title = currentLanguage.name;
  }

  private handleWindowClick(ev: MouseEvent): void {
    const buttonElement = this.buttonElementRef()?.nativeElement;
    const menuElement = this.menuElementRef()?.nativeElement;

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
