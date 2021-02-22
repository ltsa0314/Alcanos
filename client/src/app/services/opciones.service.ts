import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Opcion } from '../models/opcion.model';

@Injectable({
  providedIn: 'root'
})
export class OpcionesService {

  private baseUrl = environment.apiUrl;
  private controller = "opciones";

  constructor(private httpService: HttpClient) {}

  public getAll(): Observable<Opcion[]> {
    return this.httpService.get<Opcion[]>(
      `${this.baseUrl}/${this.controller}`
    );
  }

  public GetById(id: number): Observable<Opcion> {
    return this.httpService.get<Opcion>(
      `${this.baseUrl}/${this.controller}/${id}`
    );
  }

  public Insert(model: Opcion): Observable<Opcion> {
    return this.httpService.post<Opcion>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Update(model: Opcion): Observable<any> {
    return this.httpService.put<Opcion>(
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
