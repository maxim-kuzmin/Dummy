import { Component, inject, signal } from '@angular/core';
import { Item } from './app-nav.types';
import { AppNavItems } from './items/app-nav-items.component';
import { PageService } from '~shared/page/page.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'nav[app-nav]',
  templateUrl: './app-nav.component.html',
  imports: [AppNavItems],
})
export class AppNav {
  private readonly router = inject(ActivatedRoute);
  private readonly pageService = inject(PageService);

  protected readonly items;

  constructor() {
    this.items = signal<Item[]>(createFakeData(''));
  }
}

function createFakeData(url: string): Item[] {
  console.log('MAKC:url', url);
  let key = 0;

  return [
    createItem(++key, '11111', '/fake/11111', [
      createItem(++key, '11111-1', '/fake/11111-1', []),
      createItem(++key, '11111-2', '/fake/11111-2', []),
      createItem(++key, '11111-3', '/fake/11111-3', [
        createItem(++key, '11111-3-1', '/fake/11111-3-1', []),
        createItem(++key, '11111-3-2', '/fake/11111-3-2', []),
        createItem(++key, '11111-3-3', '/fake/11111-3-3', [
          createItem(++key, '11111-3-3-1', '/fake/11111-3-3-1', []),
          createItem(++key, '11111-3-3-2', '/fake/11111-3-3-2', []),
          createItem(++key, '11111-3-3-3', '/fake/11111-3-3-3', [], true),
          createItem(++key, '11111-3-3-4', '/fake/11111-3-3-4', []),
          createItem(++key, '11111-3-3-5', '/fake/11111-3-3-5', []),
        ]),
        createItem(++key, '11111-3-4', '/fake/11111-3-4', []),
        createItem(++key, '11111-3-5', '/fake/11111-3-5', []),
      ]),
      createItem(++key, '11111-4', '/fake/11111-4', []),
      createItem(++key, '11111-5', '/fake/11111-5', []),
    ]),
    createItem(++key, '22222', '/fake/22222', []),
    createItem(++key, '33333', '/fake/33333', []),
    createItem(++key, '44444', '/fake/44444', []),
    createItem(++key, '55555', '/fake/55555', []),
  ];
}

function createItem(
  key: number,
  text: string,
  url: string,
  children: Item[],
  selected: boolean = false
): Item {
  return {
    key,
    text,
    url,
    children,
    selected,
  } as Item;
}
