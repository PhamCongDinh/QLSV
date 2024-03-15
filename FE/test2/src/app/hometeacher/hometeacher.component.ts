import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../services/teacher.service';
import { PointUpdateRequest } from '../models/PointUpdateRequest ';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-hometeacher',
  templateUrl: './hometeacher.component.html',
  styleUrl: './hometeacher.component.scss'
})
export class HometeacherComponent implements OnInit {
  constructor(private hometeach: TeacherService, private http: HttpClient, private router: Router) { }
  ngOnInit(): void {
    this.courseofteach();
  }
  logout() {
    localStorage.clear();
    this.router.navigate(['']);
  }


  coursesteach: { id: number, courseName: string }[] = [];
  courseofteach() {
    this.hometeach.courseofteach().subscribe(
      (response: any) => {
        if (response.message === "Success") {
          this.coursesteach = response.data;
          console.log(this.coursesteach)
        } else {
          console.error("Error occurred: " + response.message);
        }
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  selected: string = "";
  studentDetails: any[] = [];
  showstudent() {
    if (this.selected) {
      this.hometeach.stuofcourse(this.selected).subscribe(
        (response: any) => {
          if (response.message === "Success") {
            this.studentDetails = response.data;
          } else {
            console.error("Error occurred: " + response.message);
          }
        },
        (error: any) => {
          console.log(error);
        }
      )
    }
  }


  submitScores() {
    const pointUpdates: PointUpdateRequest[] = this.studentDetails.map(item => {
      return {
        studentId: item.studentid,
        courseId: item.id,
        pointProcess: item.pointProcess,
        pointTest: item.pointTest
      };
    });

    this.http.post<any>('https://localhost:7169/api/Teacher/update-scores', pointUpdates)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.error('Error occurred while updating scores:', error);
      });
  }


}
