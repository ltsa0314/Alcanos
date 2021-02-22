import { UsuarioRol } from './../../../models/usuario-rol.model';
import { Rol } from './../../../models/rol.model';
import { UsuarioRolesService } from './../../../services/usuario-roles.service';
import { RolesService } from './../../../services/roles.service';
import { UsuariosService } from './../../../services/usuarios.service';
import { Usuario } from './../../../models/usuario.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-usuarios-form',
  templateUrl: './usuarios-form.component.html',
  styleUrls: ['./usuarios-form.component.scss'],
})
export class UsuariosFormComponent implements OnInit {
  title: string = 'Insertar';
  isInfo: boolean = false;
  id: number = 0;
  model: Usuario = new Usuario();
  roles: Rol[] = [];
  rolId: number = 0;
  usuarioRoles: UsuarioRol[] = [];
  constructor(
    private location: Location,
    private srvUsuarios: UsuariosService,
    private srvRoles: RolesService,
    private srvUsuarioRoles: UsuarioRolesService,
    public route: ActivatedRoute,
    public router: Router
  ) {
    this.title = this.route.snapshot.url[0].path;
    this.isInfo = this.route.snapshot.url[0].path === 'info' ? true : false;

    const { id } = this.route.snapshot.params;

    this.srvUsuarios.GetById(id).subscribe((response) => {
      if (!response) this.router.navigateByUrl('/usuarios');
      this.model = response;
      this.loadRoles();
    });

    this.srvRoles.getAll().subscribe((response) => {
      this.roles = response;
    });
  }

  loadRoles() {
    this.srvUsuarioRoles.getAll(this.model.UsuarioId).subscribe((response) => {
      this.usuarioRoles = response;
    });
  }
  ngOnInit(): void {}

  onCancel(): void {
    this.location.back();
  }
  onSave(): void {
    if (this.title === 'insert') {
      this.srvUsuarios.Insert(this.model).subscribe((result) => {
        this.location.back();
      });
    }
    if (this.title === 'update') {
      this.srvUsuarios.Update(this.model).subscribe((result) => {
        this.location.back();
      });
    }
  }

  onAddRol(usuarioId: number) {
    this.srvUsuarioRoles
      .Insert({ UsuarioId: usuarioId, RolId: this.rolId })
      .subscribe(() => {
        this.loadRoles();
      });
  }
  onDeleteRol(usuarioId: number, rolId: number) {
    this.srvUsuarioRoles.Delete(usuarioId, rolId).subscribe(() => {
      this.loadRoles();
    });
  }
  getNombreRol(id: number) {
    return this.roles.find((x) => x.RolId == id)?.Nombre;
  }
}
