import { Component, inject } from '@angular/core';
import { AppMainService } from './app-main.service';

@Component({
  selector: 'main[app-main]',
  templateUrl: './app-main.component.html',
})
export class AppMain {
  private readonly service = inject(AppMainService);

  protected readonly data = this.service.componentData;
}
