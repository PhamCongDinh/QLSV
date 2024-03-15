import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'Application/json' })
}
@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private apiurl = "https://localhost:7169/api/Students"
  constructor(private http: HttpClient) { }
  studentbyid(): Observable<any> {
    var studentid = localStorage.getItem("studentId");
    const url = `${this.apiurl}/studentbyid?id=${studentid}`;
    return this.http.get(url, httpOptions).pipe();
  }
  courseterm(data: any): Observable<any> {
    const url = "https://localhost:7169/api/Courses/cousrebyterm";
    return this.http.post(url, data);
  }
  coursebyid(id: string): Observable<any> {
    const url = `https://localhost:7169/api/Courses/coursebyid?id=${id}`;
    return this.http.get(url, httpOptions).pipe();

  }
  dkyhp(data: any): Observable<any> {
    const url = `https://localhost:7169/api/Courses/dkymon`;
    return this.http.post(url, data);

  }
  hpofstu(): Observable<any> {
    var studentid = localStorage.getItem("studentId");
    const url = `https://localhost:7169/api/Courses/coursebystuId?id=${studentid}`;
    return this.http.get(url, httpOptions).pipe();

  }
  huyhp(id: string): Observable<any> {
    const url = `https://localhost:7169/api/Courses/huydky?id=${id}`;
    return this.http.delete(url, httpOptions).pipe();

  }
  hocky(): Observable<any> {
    const url = "https://localhost:7169/api/Students/hocky";
    return this.http.get(url, httpOptions).pipe();
  }
}