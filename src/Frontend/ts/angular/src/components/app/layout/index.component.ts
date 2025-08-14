import { Component } from '@angular/core';
import { AppHeader } from "../header/index.component";
import { AppNav } from "../nav/index.component";
import { AppMain } from "../main/index.component";
import { AppFooter } from "../footer/index.component";

@Component({
  selector: 'div[app-layout]',
  templateUrl: './index.component.html',
  imports: [AppHeader, AppNav, AppMain, AppFooter],
})
export class AppLayout {}
