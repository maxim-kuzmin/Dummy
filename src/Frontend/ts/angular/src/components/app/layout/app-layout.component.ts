import { Component } from '@angular/core';
import { AppHeader } from '../header/app-header.component';
import { AppNav } from '../nav/app-nav.component';
import { AppMain } from '../main/app-main.component';
import { AppFooter } from '../footer/app-footer.component';

@Component({
  selector: 'div[app-layout]',
  templateUrl: './app-layout.component.html',
  imports: [AppHeader, AppNav, AppMain, AppFooter],
})
export class AppLayout {}
