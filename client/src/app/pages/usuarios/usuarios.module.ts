import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuariosGridComponent } from './usuarios-grid/usuarios-grid.component';
import { UsuariosFormComponent } from './usuarios-form/usuarios-form.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {
  NbActionsModule,
  NbButtonModule,
  NbCardModule,
  NbInputModule,
  NbListModule,
  NbSelectModule,
  NbUserModule,
} from '@nebular/theme';

const routes: Routes = [
  {
    path: '',
    component: UsuariosGridComponent,
  },
  {
    path: 'insert',
    component: UsuariosFormComponent,
  },
  {
    path: 'update/:id',
    component: UsuariosFormComponent,
  },
  {
    path: 'info/:id',
    component: UsuariosFormComponent,
  },
];

@NgModule({
  declarations: [UsuariosGridComponent, UsuariosFormComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    NbCardModule,
    NbActionsModule,
    NbUserModule,
    NbButtonModule,
    NbInputModule,
    NbSelectModule,
    NbListModule
  ],
  exports: [RouterModule],
})
export class UsuariosModule {}
