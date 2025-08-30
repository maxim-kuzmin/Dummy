import {
  Component,
  computed,
  ElementRef,
  inject,
  OnDestroy,
  OnInit,
  signal,
  viewChild,
} from '@angular/core';
import { LanguageService } from '~shared/language/language.service';
import { NavigationEnd, Router } from '@angular/router';
import { Language } from './app-language.types';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'nav[app-language]',
  templateUrl: './app-language.component.html',
})
export class AppLanguage implements OnInit, OnDestroy {
  private readonly router = inject(Router);
  private readonly languageService = inject(LanguageService);

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

  protected currentLanguageValue = '';

  protected readonly menuStyle = computed(() => ({
    visibility: this.isMenuOpen() ? 'visible' : 'hidden',
  }));

  protected readonly languages = computed(() => {
    const currentLanguageKey = this.languageService.getCurrentLanguageKey();
    const currentUrl = this.currentUrl();

    return [
      this.createLanguage(
        this.languageService.ruLanguageKey,
        currentLanguageKey,
        currentUrl
      ),
      this.createLanguage(
        this.languageService.enLanguageKey,
        currentLanguageKey,
        currentUrl
      ),
    ];
  });

  constructor() {
    this.handleWindowClick = this.handleWindowClick.bind(this);
  }

  ngOnDestroy(): void {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', this.handleWindowClick);
    }
  }

  ngOnInit(): void {
    this.currentLanguageValue = this.languageService.getCurrentLanguageValue();

    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', this.handleWindowClick);
    }
  }

  private createLanguage(
    key: string,
    currentLanguageKey: string,
    currentUrl: string
  ): Language {
    return {
      key,
      value: this.languageService.getLanguageValueByKey(key),
      url: this.languageService.createLocalizedUrl(key, currentUrl),
      selected: key === currentLanguageKey,
    } as Language;
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
