import { UsuariosService } from './../../../services/usuarios.service';
import { Usuario } from './../../../models/usuario.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-usuarios-grid',
  templateUrl: './usuarios-grid.component.html',
  styleUrls: ['./usuarios-grid.component.scss']
})
export class UsuariosGridComponent implements OnInit {
  data: Usuario[] = [];
  constructor(public srvUsuarios: UsuariosService, private router: Router) { }

  ngOnInit(): void {
    this.loadData();
  }
  loadData() {
    this.data = [];
    this.srvUsuarios.getAll().subscribe((result) => (this.data = result));
  }
  onInfo(id: number) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/info/' + id,
    ]);
  }
  onUpdate(id: number) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/update/' + id,
    ]);
  }
  onDelete(id: number) {
    Swal.fire({
      title: 'Eliminar!',
      text: 'Seguro que desea eliminar el registro',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No',
    }).then((result) => {
      if (result.isConfirmed) {
        this.srvUsuarios.Delete(id).subscribe(() => this.loadData(),(error)=> {
          Swal.fire({
            title: 'Error!',
            text: error.error,
            icon: 'error',
            confirmButtonText: 'OK'
          })
        });

      }
    });


  }

}
