import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, switchMap, map, filter } from 'rxjs';
import { environment } from 'src/enviroments/enviroment';
import { CountryService } from './country.service';
import { State } from './../models/state.model';

const BaseUrl = environment.baseUrl+"/api/State";
@Injectable({
  providedIn: 'root'
})
export class StateService {

  constructor(private http: HttpClient,private countryservice:CountryService) { }

  getAllStateDetail<T>(): Observable<T>{
    return this.http.get<T>(`${BaseUrl}`)
  }
  
  // getAllStateDetail<T>(pageIndex: number, pageSize: number): Observable<T>{
  //   let params = new HttpParams()
  //   .set("pageIndex", pageIndex.toString())
  //   .set("pageSize", pageSize.toString())
  //   return this.http.get<T>(`${BaseUrl}/search?${params.toString()}`)
  // }
  getDropdownByCountry<T>(countryId: number): Observable<T[]> {
    let params = new HttpParams().set("countryId", countryId.toString());
    return this.http.get<T[]>(`${BaseUrl}${params.toString()}`);
  }
  getStateDetail<T>(stateId: number): Observable<T> {
    return this.http.get<T>(`${BaseUrl}/${stateId}`);
  }

  addState<T>(state: T): Observable<T> {
    return this.http.post<T>(BaseUrl, state);
  }
  
  updateState<T>(stateId: number, state  : any): Observable<T> {
    return this.http.put<T>(`${BaseUrl}/${stateId}`, state);
  }

}
