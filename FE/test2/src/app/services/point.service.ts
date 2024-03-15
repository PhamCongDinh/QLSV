import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class PointService {

  constructor(private http: HttpClient) { }
  pointbyid(): Observable<any> {
    var studentid = localStorage.getItem("studentId");
    const url = `https://localhost:7169/api/Courses/pointbyid?id=${studentid}`;
    return this.http.get(url, httpOptions).pipe();

  }
}
