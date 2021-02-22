import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesGridComponent } from './roles-grid/roles-grid.component';
import { RolesFormComponent } from './roles-form/roles-form.component';
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
    component: RolesGridComponent,
  },
  {
    path: 'insert',
    component: RolesFormComponent,
  },
  {
    path: 'update/:id',
    component: RolesFormComponent,
  },
  {
    path: 'info/:id',
    component: RolesFormComponent,
  },
];

@NgModule({
  declarations: [RolesGridComponent, RolesFormComponent],
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
    NbListModule,
  ],
  exports: [RouterModule],
})
export class RolesModule {}
