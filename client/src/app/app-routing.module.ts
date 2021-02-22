import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {
    path: 'usuarios',
    loadChildren: () =>
      import('./pages/usuarios/usuarios.module').then((m) => m.UsuariosModule),
  },
  {
    path: 'roles',
    loadChildren: () =>
      import('./pages/roles/roles.module').then(
        (m) => m.RolesModule
      ),
  },
  {
    path: 'inicio',
    component: HomeComponent
  },
  {
    path: '**', redirectTo:"/inicio"
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
