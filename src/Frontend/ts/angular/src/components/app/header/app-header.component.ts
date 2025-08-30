import { Component } from '@angular/core';
import { AppLanguage } from "../language/app-language.component";
import { RouterLink } from "@angular/router";

@Component({
  selector: 'header[app-header]',
  templateUrl: './app-header.component.html',
  imports: [AppLanguage, RouterLink],
})
export class AppHeader {}
