import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class ResourcesService {
  translate(key: string, list?: unknown[]): string {
    switch(key) {
      case 'page.fake.title': {
        const id = list ? String(list[0]) : ''

        return `${$localize`:@@page.fake.title:@@`} ${id}`;
      }
      default:
        throw Error(`ResourcesService: Unknown resource key: "${key}"`)
    }
  }
}
