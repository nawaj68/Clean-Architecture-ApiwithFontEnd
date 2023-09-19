import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/enviroments/enviroment';

const BaseUrl = environment.baseUrl+"/api/Country"

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private http : HttpClient) { }

  // getAllCountryDetail<T>(pageIndex: number, pageSize: number): Observable<T>{
  //   let params = new HttpParams()
  //   .set("pageIndex", pageIndex.toString())
  //   .set("pageSize", pageSize.toString())
  //   // .set("searchText", searchText);
  //   return this.http.get<T>(`${BaseUrl}/search?${params.toString()}`)
  // }
  getAllCountryDetail<T>(): Observable<T> {
    return this.http.get<T>(`${BaseUrl}`);
  }
  getCountryDetail<T>(countryId: number): Observable<T> {
    return this.http.get<T>(`${BaseUrl}/${countryId}`);
  }
  addCountry<T>(country: T): Observable<T> {
    return this.http.post<T>(BaseUrl, country);
  }
  updateCountry<T>(countryId: number, country  : any): Observable<T> {
    return this.http.put<T>(`${BaseUrl}/${countryId}`, country);
  }
}
