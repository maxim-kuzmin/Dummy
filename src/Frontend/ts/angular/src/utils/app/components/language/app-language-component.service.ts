import {
  computed,
  ElementRef,
  inject,
  Injectable,
  Signal,
  signal,
} from '@angular/core';
import { LanguageService } from '~/utils/shared/language/language.service';
import {
  AppLanguageComponentData,
  AppLanguageComponentItem,
} from './app-language-component.types';
import { NavigationEnd, Router } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';

@Injectable({
  providedIn: 'root',
})
export class AppLanguageComponentService {
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

  private readonly data = new AppLanguageComponentData();

  get items() {
    return this.data.items;
  }

  get menuStyle() {
    return this.data.menuStyle;
  }

  get title() {
    return this.data.title;
  }

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
    const currentLanguageCode = this.languageService.getCurrentLanguageCode();
    const currentUrl = this.currentUrl();

    this.data.items.set(
      [
        this.languageService.ruLanguageCode,
        this.languageService.enLanguageCode,
      ].map(
        (code) =>
          ({
            code,
            name: this.languageService.getLanguageNameByCode(code),
            selected: code === currentLanguageCode,
            url: this.languageService.createLocalizedUrl(code, currentUrl),
          } as AppLanguageComponentItem)
      )
    );

    this.data.menuStyle.set({
      visibility: this.isMenuOpen() ? 'visible' : 'hidden',
    });

    this.data.title = this.languageService.getCurrentLanguageName();
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
