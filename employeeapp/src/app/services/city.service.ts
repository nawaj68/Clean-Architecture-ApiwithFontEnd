import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/enviroment';

const BaseUrl = environment.baseUrl+"/api/City";

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http : HttpClient) { }

  
  getDropdownByState<T>(stateId: number): Observable<T[]> {
    let params = new HttpParams().set("stateId", stateId.toString());
    return this.http.get<T[]>(`${BaseUrl}/dropdown?${params.toString()}`);
  }
  
  getAllCityDetail<T>(): Observable<T> {
    return this.http.get<T>(`${BaseUrl}`);
  }
  //  getAllCityDetail<T>(pageIndex: number, pageSize: number): Observable<T> {
  //   let params = new HttpParams()
  //   .set("pageIndex", pageIndex.toString())
  //   .set("pageSize", pageSize.toString())
  //   return this.http.get<T>(`${BaseUrl}/search?${params.toString()}`);
  //  }
  
  getCityDetail<T>(cityId: number): Observable<T> {
    return this.http.get<T>(`${BaseUrl}/${cityId}`);
  }

  addCity<T>(city: T): Observable<T> {
    return this.http.post<T>(BaseUrl, city);
  }
  
  updateCity<T>(cityId: number, city  : any): Observable<T> {
    return this.http.put<T>(`${BaseUrl}/${cityId}`, city);
  }
}
