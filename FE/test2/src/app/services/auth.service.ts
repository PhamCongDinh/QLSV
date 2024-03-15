import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private apiurl = "https://localhost:7169/api/Authen/";
  constructor(private http: HttpClient) { }
  login(data: any): Observable<any> {
    const url = `${this.apiurl}login`;
    return this.http.post(url, data);
  }
  register(data: any): Observable<any> {
    const url = `${this.apiurl}register`;
    return this.http.post(url, data);
  }
}
