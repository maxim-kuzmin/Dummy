import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppLayout } from "../components/app/layout/index.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AppLayout],
  templateUrl: './app.html',
})
export class App {
  private name1 = '"';
  private name2 = 'Dummy';

  protected readonly title = signal($localize`@@greeting ${this.name1}${this.name2}${this.name1}`);
}
