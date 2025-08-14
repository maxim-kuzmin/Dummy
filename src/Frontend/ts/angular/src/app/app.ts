import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppLayout } from "../components/app/layout/index.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AppLayout],
  templateUrl: './app.html',
})
export class App {}
