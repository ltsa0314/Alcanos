import { Component } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  items: NbMenuItem[] = [
    {
      title: 'Usuarios',
      icon: 'people-outline',
      link: '/usuarios'
    },
    {
      title: 'Roles',
      icon: 'lock-outline',
      link: '/roles'
    }
  ];
  title = 'Alcanos';
}
