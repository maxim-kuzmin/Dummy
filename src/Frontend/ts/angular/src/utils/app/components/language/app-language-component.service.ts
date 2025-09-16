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

  private readonly currentUrl = computed(() => {
    const routerEvent = this.routerEvents();

    return routerEvent && routerEvent instanceof NavigationEnd
      ? routerEvent.url
      : '/';
  });

  private buttonElementRef!: Signal<ElementRef<HTMLButtonElement> | undefined>;
  private menuElementRef!: Signal<ElementRef<HTMLUListElement> | undefined>;

  readonly data = {
    currentLanguageName: '',
    items: signal([]),
    menuStyle: computed(() => ({
      visibility: this.isMenuOpen() ? 'visible' : 'hidden',
    })),
  } as AppLanguageComponentData;

  constructor() {
    this.handleWindowClick = this.handleWindowClick.bind(this);
  }

  load(): void {
    this.data.currentLanguageName =
      this.languageService.getCurrentLanguageName();

    this.data.items.set(this.createLanguages());
  }

  onAfterViewInit(
    buttonElementRef: Signal<ElementRef<HTMLButtonElement> | undefined>,
    menuElementRef: Signal<ElementRef<HTMLUListElement> | undefined>
  ): void {
    this.buttonElementRef = buttonElementRef;
    this.menuElementRef = menuElementRef;
  }

  onDestroy(): void {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', this.handleWindowClick);
    }
  }

  onInit(): void {
    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', this.handleWindowClick);
    }
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

  private createLanguage(
    code: string,
    currentLanguageCode: string,
    currentUrl: string
  ): AppLanguageComponentItem {
    const name = this.languageService.getLanguageNameByCode(code);
    const url = this.languageService.createLocalizedUrl(code, currentUrl);
    const selected = code === currentLanguageCode;

    return {
      code,
      name,
      url,
      selected,
    } as AppLanguageComponentItem;
  }

  private createLanguages(): AppLanguageComponentItem[] {
    const currentUrl = this.currentUrl();
    const currentLanguageCode = this.languageService.getCurrentLanguageCode();

    return [
      this.createLanguage(
        this.languageService.ruLanguageCode,
        currentLanguageCode,
        currentUrl
      ),
      this.createLanguage(
        this.languageService.enLanguageCode,
        currentLanguageCode,
        currentUrl
      ),
    ];
  }
}
