import { inject, Injectable, Signal, signal } from '@angular/core';
import { LanguageService } from '~/utils/infrastructure/language/language.service';
import { languages } from '~/utils/shared/language/language.types';
import {
  AppLanguageComponentItem,
  AppLanguageComponentMenuStyle,
} from '../app-language-component.types';
import { AppLanguageComponentStoreDataQuery } from './app-language-component-store.types';

@Injectable({
  providedIn: 'root',
})
export class AppLanguageComponentStoreService {
  private readonly languageService = inject(LanguageService);

  private readonly _items = signal<AppLanguageComponentItem[]>([]);
  private readonly _menuStyle = signal<AppLanguageComponentMenuStyle>({
    visibility: 'hidden',
  });
  private readonly _title = signal<string>('');

  get items(): Signal<AppLanguageComponentItem[]> {
    return this._items;
  }

  get menuStyle(): Signal<AppLanguageComponentMenuStyle> {
    return this._menuStyle;
  }

  get title(): Signal<string> {
    return this._title;
  }

  load(dataQuery: AppLanguageComponentStoreDataQuery): void {
    const currentLanguage = this.languageService.getCurrentLanguage();

    this._items.set(
      [languages.russian, languages.english].map(
        (language) =>
          ({
            code: language.code,
            name: language.name,
            selected: language.code === currentLanguage.code,
            url: this.languageService.createLocalizedUrl(
              language.code,
              dataQuery.currentUrl
            ),
          } as AppLanguageComponentItem)
      )
    );

    this._menuStyle.set({
      visibility: dataQuery.isMenuOpen ? 'visible' : 'hidden',
    });

    this._title.set(currentLanguage.name);
  }
}
