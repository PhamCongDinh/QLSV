import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'Application/json' })
}
@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private http: HttpClient) { }
  courseofteach(): Observable<any> {
    var id = localStorage.getItem("teacherId");
    var url = `https://localhost:7169/api/Teacher/coursebyidteach?id=${id}`;
    return this.http.get(url, httpOptions).pipe();

  }
  stuofcourse(id: string): Observable<any> {
    var url = `https://localhost:7169/api/Teacher/studbyidcou?id=${id}`;
    return this.http.get(url, httpOptions).pipe();

  }
}
