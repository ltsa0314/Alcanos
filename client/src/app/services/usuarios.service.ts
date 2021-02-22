import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private baseUrl = environment.apiUrl;
  private controller = "usuarios";

  constructor(private httpService: HttpClient) {}

  public getAll(): Observable<Usuario[]> {
    return this.httpService.get<Usuario[]>(
      `${this.baseUrl}/${this.controller}`
    );
  }

  public GetById(id: number): Observable<Usuario> {
    return this.httpService.get<Usuario>(
      `${this.baseUrl}/${this.controller}/${id}`
    );
  }

  public Insert(model: Usuario): Observable<Usuario> {
    return this.httpService.post<Usuario>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Update(model: Usuario): Observable<any> {
    return this.httpService.put<Usuario>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Delete(id: number): Observable<any> {
    return this.httpService.delete<any>(
      `${this.baseUrl}/${this.controller}/${id}`
    );
  }
}
