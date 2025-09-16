import { Component, inject } from '@angular/core';
import { AppMainComponentService } from '~/utils/app/components/main/app-main-component.service';

@Component({
  selector: 'main[app-main]',
  templateUrl: './app-main.component.html',
})
export class AppMain {
  private readonly service = inject(AppMainComponentService);

  protected readonly data = this.service.componentData;
}
