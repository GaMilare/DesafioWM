import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { FabricanteModel } from '../models/FabricanteModel';
import { ModelosModel } from '../models/ModelosModel';
import { Anuncio } from '../models/Anuncio';
import { VersaoModel } from '../models/VersaoModel';

@Injectable({
  providedIn: 'root'
})
export class AnunciosService {
  wmBaseUrl = environment.wmBaseUrl;
  baseUrl = environment.apiBaseUrl;
  
  constructor(private http: HttpClient) { }
  
  
  // getAll() {
  //   return this.http.get("");
  // }
  
  getManufacturer(): Observable<FabricanteModel[]> {
    return this.http.get<FabricanteModel[]>(`${this.wmBaseUrl}/api/OnlineChallenge/Make`);
  }
  
  getModelsByManufacturerId(id: number): Observable<ModelosModel[]>{
    return this.http.get<ModelosModel[]>(`${this.wmBaseUrl}/api/OnlineChallenge/Model?MakeID=${id}`);
  }

  getVersionByModelId(id: number): Observable<VersaoModel[]>{
    return this.http.get<VersaoModel[]>(`${this.wmBaseUrl}/api/OnlineChallenge/Version?ModelID=${id}`);
  }
  
  // getByAll(id: number) {
  //   return this.http.get("url/${id}");
  // }
  
  post(anuncio: Anuncio){
    return this.http.post(`${this.baseUrl}`, anuncio);
  }
  
  put(id:number, anuncio: Anuncio){
    return this.http.put(`${this.baseUrl}/${id}`, anuncio);
  }
  
}
