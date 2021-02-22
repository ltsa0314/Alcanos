import { RolOpcionesService } from './../../../services/rol-opciones.service';
import { Component, OnInit } from '@angular/core';
import { Opcion } from 'src/app/models/opcion.model';
import { RolOpcion } from 'src/app/models/rol-opcion.model';
import { Rol } from 'src/app/models/rol.model';
import { OpcionesService } from 'src/app/services/opciones.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { RolesService } from 'src/app/services/roles.service';

@Component({
  selector: 'app-roles-form',
  templateUrl: './roles-form.component.html',
  styleUrls: ['./roles-form.component.scss'],
})
export class RolesFormComponent implements OnInit {
  title: string = 'Insertar';
  isInfo: boolean = false;
  id: number = 0;
  model: Rol = new Rol();
  opciones: Opcion[] = [];
  opcionId: number = 0;
  rolOpciones: RolOpcion[] = [];
  constructor(
    private location: Location,
    private srvRoles: RolesService,
    private srvOpciones: OpcionesService,
    private srvRolOpciones: RolOpcionesService,
    public route: ActivatedRoute,
    public router: Router
  ) {
    this.title = this.route.snapshot.url[0].path;
    this.isInfo = this.route.snapshot.url[0].path === 'info' ? true : false;

    const { id } = this.route.snapshot.params;

    this.srvRoles.GetById(id).subscribe((response) => {
      if (!response) this.router.navigateByUrl('/roles');
      this.model = response;
      this.loadOpciones();
    });

    this.srvOpciones.getAll().subscribe((response) => {
      this.opciones = response;
    });
  }

  ngOnInit(): void {}

  loadOpciones() {
    this.srvRolOpciones.getAll(this.model.RolId).subscribe((response) => {
      this.rolOpciones = response;
    });
  }

  onCancel(): void {
    this.location.back();
  }
  onSave(): void {
    if (this.title === 'insert') {
      this.srvRoles.Insert(this.model).subscribe((result) => {
        this.location.back();
      });
    }
    if (this.title === 'update') {
      this.srvRoles.Update(this.model).subscribe((result) => {
        this.location.back();
      });
    }
  }

  onAddRol(rolId: number) {
    this.srvRolOpciones
      .Insert({ RolId: rolId, OpcionId: this.opcionId })
      .subscribe(() => {
        this.loadOpciones();
      });
  }
  onDeleteRol(rolId: number, opcionId: number) {
    this.srvRolOpciones.Delete(rolId, opcionId).subscribe(() => {
      this.loadOpciones();
    });
  }
  getNombreRol(id: number) {
    return this.opciones.find((x) => x.OpcionId == id)?.Nombre;
  }
}
