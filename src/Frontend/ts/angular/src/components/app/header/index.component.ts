import { Component } from '@angular/core';
import { AppLanguage } from "../language/index.component";

@Component({
  selector: 'header[app-header]',
  templateUrl: './index.component.html',
  imports: [AppLanguage],
})
export class AppHeader {}
