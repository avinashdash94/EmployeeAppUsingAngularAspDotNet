import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "http://localhost:50167/api";
  readonly PhotoUrl = "http://localhost:50167/Photos";
  constructor(private http: HttpClient) { }

  //**********Department Operations************
  getDepList(): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl + '/department');
  }

  addDepartent(val:any){
    return this.http.post<any>(this.APIUrl + '/Department', val);
  }

  updateDepartent(val:any){
    return this.http.put<any>(this.APIUrl + '/Department', val);
  }

  deleteDepartent(val:any){
    return this.http.delete<any>(this.APIUrl + '/Department?id=' + val);
  }


  //**********Employee Operations************
  getEmpList(): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl + '/Employee');
  }

  addEmployee(val:any){
    console.log('comming')
    return this.http.post<any>(this.APIUrl + '/Employee', val);
  }

  updateEmployee(val:any){
    return this.http.put<any>(this.APIUrl + '/Employee', val);
  }

  deleteEmployee(val:any){
    return this.http.delete<any>(this.APIUrl + '/Employee?id=' + val);
  }

  UploadPhoto(val:any){
    return this.http.post<any>(this.APIUrl + '/Employee/SaveFile' , val);
  }

  getAllDepartmentNames() : Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl + '/Employee/GetAllDepartmentNames');
  }
}
