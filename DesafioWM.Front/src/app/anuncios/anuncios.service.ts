import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { FabricanteModel } from '../models/FabricanteModel';
import { ModelosModel } from '../models/ModelosModel';
import { Anuncio } from '../models/Anuncio';
import { VersaoModel } from '../models/VersaoModel';
import { BaseResponse } from '../models/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class AnunciosService {
  wmBaseUrl = environment.wmBaseUrl;
  baseUrl = environment.apiBaseUrl;
  
  constructor(private http: HttpClient) { } 
  
  
  getAll() : Observable<BaseResponse<Anuncio[]>> {
    return this.http.get<BaseResponse<Anuncio[]>>(`${this.baseUrl}/api/Anuncios/GetAll`);
  }
  
  getManufacturer(): Observable<FabricanteModel[]> {
    return this.http.get<FabricanteModel[]>(`${this.wmBaseUrl}/api/OnlineChallenge/Make`);
  }
  
  getModelsByManufacturerId(id: number): Observable<ModelosModel[]>{
    return this.http.get<ModelosModel[]>(`${this.wmBaseUrl}/api/OnlineChallenge/Model?MakeID=${id}`);
  }

  getVersionByModelId(id: number): Observable<VersaoModel[]>{
    return this.http.get<VersaoModel[]>(`${this.wmBaseUrl}/api/OnlineChallenge/Version?ModelID=${id}`);
  }
    
  post(anuncio: Anuncio) : Observable<BaseResponse<boolean>> {
    return this.http.post<BaseResponse<boolean>>(`${this.baseUrl}/api/Anuncios`, anuncio);
  }
  
  put(anuncio: Anuncio): Observable<BaseResponse<boolean>> {
    return this.http.put<BaseResponse<boolean>>(`${this.baseUrl}/api/Anuncios`, anuncio);
  }

  delete(id: number): Observable<BaseResponse<boolean>> {
    return this.http.delete<BaseResponse<boolean>>(`${this.baseUrl}/api/Anuncios?id=${id}`);
  }
  
}
