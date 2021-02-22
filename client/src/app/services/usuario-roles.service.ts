import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UsuarioRol } from '../models/usuario-rol.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioRolesService {
  private baseUrl = environment.apiUrl;
  private controller = "usuarioroles";

  constructor(private httpService: HttpClient) {}

  public getAll(usuarioId:number): Observable<UsuarioRol[]> {
    return this.httpService.get<UsuarioRol[]>(
      `${this.baseUrl}/${this.controller}?usuarioId=${usuarioId}`
    );
  }

  public GetById(id: number): Observable<UsuarioRol> {
    return this.httpService.get<UsuarioRol>(
      `${this.baseUrl}/${this.controller}/${id}`
    );
  }

  public Insert(model: UsuarioRol): Observable<UsuarioRol> {
    return this.httpService.post<UsuarioRol>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Update(model: UsuarioRol): Observable<any> {
    return this.httpService.put<UsuarioRol>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Delete(usuarioId: number, rolId:number): Observable<any> {
    return this.httpService.delete<any>(
      `${this.baseUrl}/${this.controller}?usuarioId=${usuarioId}&rolId=${rolId}`,
    );
  }
}
