import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RolOpcion } from '../models/rol-opcion.model';

@Injectable({
  providedIn: 'root'
})
export class RolOpcionesService {

  private baseUrl = environment.apiUrl;
  private controller = "rolopciones";

  constructor(private httpService: HttpClient) {}

  public getAll(rolId:number): Observable<RolOpcion[]> {
    return this.httpService.get<RolOpcion[]>(
      `${this.baseUrl}/${this.controller}?rolId=${rolId}`
    );
  }

  public GetById(id: number): Observable<RolOpcion> {
    return this.httpService.get<RolOpcion>(
      `${this.baseUrl}/${this.controller}/${id}`
    );
  }

  public Insert(model: RolOpcion): Observable<RolOpcion> {
    return this.httpService.post<RolOpcion>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Update(model: RolOpcion): Observable<any> {
    return this.httpService.put<RolOpcion>(
      `${this.baseUrl}/${this.controller}`,
      model
    );
  }

  Delete(rolId: number , opcionId : number): Observable<any> {
    return this.httpService.delete<any>(
      `${this.baseUrl}/${this.controller}?rolId=${rolId}&opcionId=${opcionId}`,
    );
  }
}
