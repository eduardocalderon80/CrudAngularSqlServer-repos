import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ValueModel } from '../models/ValueModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CrudServicioService {

  urlBase = 'https://localhost:44381/api/values'
  constructor( private http: HttpClient ) { }

  getAllValue() : Observable<ValueModel[]>{
    return this.http.get<ValueModel[]>(this.urlBase)
  }

  getValorId(id: string) : Observable<ValueModel>{
    return this.http.get<ValueModel>(`${this.urlBase}/${id}`)
  }

  actualizarValor(valor: ValueModel){
    return this.http.put(`${this.urlBase}/${valor.id}`, valor);
  }

  nuevoValor(valor: ValueModel){
    return this.http.post(`${this.urlBase}/insertar`, valor);
  }

  eliminarValor(id: string){
    return this.http.delete(`${this.urlBase}/${id}`);
  }
}
