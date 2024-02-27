import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:5113/api";

  constructor(private http:HttpClient) { }

  /*getEmpList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employee');
  }*/
  getEmpList(): Observable<any[]> {
    console.log('Fetching employee list...');
    return this.http.get<any[]>(this.APIUrl + '/Employee').pipe(
        tap(data => console.log('Employee List:', data)),
        catchError(error => {
            console.error('Error fetching employee list:', error);
            throw error;
        })
    );
}


addEmployee(addEmployeeRequest: any): Observable<any[]> {
  return this.http.post<any[]>(this.APIUrl + '/Employee', addEmployeeRequest);
}
  updateEmployee(id: number, val: any){
    return this.http.put<any>(`${this.APIUrl}/Employee/${id}`, val);
  }

  deleteEmployee(id: number){
    return this.http.delete<any>(`${this.APIUrl}/Employee/${id}`);
  }

 
 

}
