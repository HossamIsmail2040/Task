import { LoginResponse } from './../Model/Response/LoginResponse';
import { Empolyee } from './../Model/Request/Empolyee';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmpolyeeService {

  private baseUrl = 'https://localhost:44383/api/';
  headers = new HttpHeaders({
    'Authorization': `Bearer ${sessionStorage.getItem('token')}`,
    })
  constructor(private http : HttpClient) {

  }

  public Login(data : any)
  {
    let url = 'Employee/Login';
    return this.http.post<LoginResponse>(this.baseUrl+url , data);
  }


  public getAllEmpolyee()
  {
    let url = `Employee/GetAll`;

    return this.http.get<Empolyee[]>(this.baseUrl+url , {headers : this.headers} );
  }

  public getEmpolyeeById (id : number)
  {
    let url = `Employee/GetById?employeeId=${id}`;
    return this.http.get<Empolyee>(this.baseUrl+url , {headers: this.headers});
  }

  public AddNewEmpolyee (Data : Empolyee)
  {
    let url = `Employee/Create`;
    return this.http.post(this.baseUrl+url, Data , {headers: this.headers});
  }

  public EditEmpolyee (Data : Empolyee)
  {
    let url = `Employee/Update`;
    return this.http.post(this.baseUrl+url, Data , {headers: this.headers});
  }

  public DeleteEmpolyee (id : number)
  {
    let url = `Employee/Delete?employeeId=${id}`;
    return this.http.post(this.baseUrl+url, null , {headers: this.headers});
  }
}


