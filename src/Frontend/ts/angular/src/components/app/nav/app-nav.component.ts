import { Component } from '@angular/core';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'nav[app-nav]',
  templateUrl: './app-nav.component.html',
  imports: [RouterLink],
})
export class AppNav {}
