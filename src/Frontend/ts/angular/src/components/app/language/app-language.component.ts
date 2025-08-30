import { Component, computed, inject, signal } from '@angular/core';
import { LanguageService } from '@services/language.service';

interface Language {
  key: string;
  value: string;
}

@Component({
  selector: 'nav[app-language]',
  templateUrl: './app-language.component.html',
})
export class AppLanguage {
  protected languageService = inject(LanguageService);

  private readonly isMenuOpen = signal(false);

  protected readonly menuStyle = computed(() => ({
    'visibility': this.isMenuOpen() ? 'visible' : 'hidden'
  }));

  protected readonly languages: Language[] = [
    {
      key: this.languageService.ruLanguageKey,
      value: this.languageService.languageLookup.get(this.languageService.ruLanguageKey)!,
    },
    {
      key: this.languageService.enLanguageKey,
      value: this.languageService.languageLookup.get(this.languageService.enLanguageKey)!,
    },
  ];

  protected currentLanguage = this.languageService.languageLookup.get(
    this.languageService.ruLanguageKey
  )!;

  protected toggleMenu() {
    this.isMenuOpen.set(!this.isMenuOpen())
  }
}
