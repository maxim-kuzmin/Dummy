import { Injectable } from '@angular/core';
import { LanguageCode } from '~/utils/shared/language/language.types';

@Injectable({
  providedIn: 'root',
})
export class AppNotFoundPageService {
  createPageKey(languageCode: LanguageCode): string {
    return `NotFound:${languageCode}`
  }
}
