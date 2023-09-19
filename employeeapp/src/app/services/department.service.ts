import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/enviroment';

const BaseUrl = environment.baseUrl+"/api/Department"
@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http : HttpClient) { }

  getAllDepartmentDetail<T>(): Observable<T>{
    return this.http.get<T>(`${BaseUrl}`)
  }
  getDepartmentDetail<T>(departmentId: number): Observable<T> {
    return this.http.get<T>(`${BaseUrl}/${departmentId}`);
  }
  addDepartment<T>(department: T): Observable<T> {
    return this.http.post<T>(BaseUrl, department);
  }
  updateDepartment<T>(departmentId: number, department  : any): Observable<T> {
    return this.http.put<T>(`${BaseUrl}/${departmentId}`, department);
  }
}
