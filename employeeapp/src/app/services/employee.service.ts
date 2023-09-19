import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/enviroment';

const BaseUrl = environment.baseUrl+"/api/Employee"

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http : HttpClient) { }

  // getAllEmployeeDetail<T>(): Observable<T[]> {
  //   return this.http.get<T[]>(`${BaseUrl}`);
  // }
  getAllEmployeeDetail<T>(pageIndex: number, pageSize: number): Observable<T[]> {
    let params = new HttpParams()
    .set("pageIndex", pageIndex.toString())
    .set("pageSize", pageSize.toString())
    // .set("searchText", searchText);
    return this.http.get<T[]>(`${BaseUrl}/search?${params.toString()}`);
  }
  getEmployeeDetail<T>(employeeId: number): Observable<T> {
    return this.http.get<T>(`${BaseUrl}/${employeeId}`);
  }

  addEmployee<T>(employee: T): Observable<T> {
    return this.http.post<T>(BaseUrl, employee);
  }
  updateEmployee<T>(employeeId: number, employee  : any): Observable<T> {
    return this.http.put<T>(`${BaseUrl}/${employeeId}`, employee);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${BaseUrl}/${id}`);
  }
}
