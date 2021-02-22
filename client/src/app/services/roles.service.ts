import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Rol } from '../models/rol.model';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  private baseUrl = environment.apiUrl;
  private controller = "roles";

  constructor(private httpService: HttpClient) {}

  public getAll(): Observable<Rol[]> {
    return this.httpService.get<Rol[]>(
      `${this.baseUrl}/${this.controller}`
    );
  }

  public GetById(id: number): Observable<Rol> {
    return this.httpService.get<Rol>(
      `${this.baseUrl}/${this.controller}/${id}`
    );
  }

  public Insert(model: Rol): Observable<Rol> {
    return this.httpService.post<Rol>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Update(model: Rol): Observable<any> {
    return this.httpService.put<Rol>(
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
