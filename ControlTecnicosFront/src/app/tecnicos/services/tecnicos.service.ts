import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IElemento, IElementosTecnico, ISucursal, ITecnico } from '../models/tecnico.interface';

@Injectable({
  providedIn: 'root'
})
export class TecnicosService {
  private _url: string = `https://localhost:7175/api/Tecnicos`;

  constructor(
    private _http: HttpClient
  ) { }

  obtenerSucursales(): Observable<ISucursal[]> {
    return this._http.get<ISucursal[]>(`${this._url}/sucursales`);
  }

  obtenerElementos(): Observable<IElemento[]> {
    return this._http.get<IElemento[]>(`${this._url}/elementos`);
  }

  obtenerTecnicos(): Observable<ITecnico[]> {
    return this._http.get<ITecnico[]>(this._url);
  }

  actualizarElementosTecnico(elementosTecnico: IElementosTecnico[]): Observable<boolean> {
    return this._http.post<boolean>(`${this._url}/elementos-tecnico`, elementosTecnico);
  }

  crearTecnico(tecnico: ITecnico): Observable<boolean> {
    return this._http.post<boolean>(this._url, tecnico);
  }

  actualizaTecnico(tecnico: ITecnico): Observable<boolean> {
    return this._http.put<boolean>(`${this._url}/elementos-tecnico`, tecnico);
  }

  eliminarTecnico(id: number): Observable<boolean> {
    return this._http.delete<boolean>(this._url);
  }
}
