import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Rol } from 'src/app/models/rol.model';
import { RolesService } from 'src/app/services/roles.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-roles-grid',
  templateUrl: './roles-grid.component.html',
  styleUrls: ['./roles-grid.component.scss']
})
export class RolesGridComponent implements OnInit {
  data: Rol[] = [];
  constructor(public srvRoles: RolesService, private router: Router) { }

  ngOnInit(): void {
    this.loadData();
  }
  loadData() {
    this.data = [];
    this.srvRoles.getAll().subscribe((result) => (this.data = result));
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
        this.srvRoles.Delete(id).subscribe(() => this.loadData(),(error)=> {
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
