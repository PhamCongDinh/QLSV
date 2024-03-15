import { Component, OnInit } from '@angular/core';
import { HomeService } from '../services/home.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  studentdata: any = {};
  constructor(private home: HomeService, private route: Router) { }
  ngOnInit(): void {
    this.studentbyid();
    this.courseterm();
    this.hpofstu();
    this.hocky();
  }
  hockydata: any = {}
  hocky() {
    this.home.hocky().subscribe(
      response => {
        this.hockydata = response.data[0];
        console.log(this.hockydata);
      },
      error => {
        console.error('Error', error);
      }
    )
  }
  studentbyid() {
    this.home.studentbyid().subscribe(
      response => {
        this.studentdata = response.data[0];
        console.log(this.studentdata);
        localStorage.setItem("cohortName", this.studentdata.cohortName);
        localStorage.setItem("departmentName", this.studentdata.departmentName);
      },
      error => {
        console.error('Error fetching student details', error);
      }
    )
  }
  courses: { id: number, courseName: string }[] = [];
  courseterm() {
    const data = {
      "cohName": localStorage.getItem("cohortName"),
      "depname": localStorage.getItem("departmentName")


    };
    this.home.courseterm(data).subscribe(
      (response: any) => {
        if (response.message === "Success") {
          this.courses = response.data;
          console.log(this.courses)
        } else {
          console.error("Error occurred: " + response.message);
        }
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
  selectedCourseId: string = "";
  courseDetails: any[] = [];
  showCourseDetails() {
    if (this.selectedCourseId) {
      this.home.coursebyid(this.selectedCourseId).subscribe(
        (response: any) => {
          if (response.message === "Success") {
            this.courseDetails = response.data;
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

  datamon: any = {};
  dkymon() {
    // Lặp qua các chi tiết môn học để kiểm tra checkbox đã được chọn
    this.courseDetails.forEach(courseDetail => {
      if (courseDetail.selected) {
        console.log(courseDetail.id);
        // Gọi API để đăng ký môn học
        const data = {
          "IdStu": localStorage.getItem("studentId"),
          "IdCour": courseDetail.id

        }

        this.home.dkyhp(data).subscribe(
          (response: any) => {
            if (response.message === "Success") {
              alert("Đã đăng ký môn học thành công")
              console.log("Đã đăng ký môn học thành công:", response.data);

              this.hpofstu();
            } else {
              alert("bạn đã đăng ký môn học này rồi")
            }
          },
          (error: any) => {
            console.log(error);
          }
        );
      }
    });
  }



  Coursedata: any[] = [];

  hpofstu() {
    this.home.hpofstu().subscribe(
      (response: any) => {
        if (response.message === "Success") {
          this.Coursedata = response.data;
        } else {
          console.error("Error fetching course data:", response.message);
        }
      },
      (error: any) => {
        console.error('Error fetching course data', error);
      }
    );
  }



  logout() {
    localStorage.clear();
    this.route.navigate(['']);
  }



  deletehp(id: string): void {
    const confirmDelete = confirm('Are you sure you want to delete this student?');
    if (confirmDelete) {
      this.home.huyhp(id).subscribe(
        () => {
          // Refresh the data after deletion
          this.hpofstu();
        },
        error => {
          console.error('Error deleting student:', error);
        }
      );
    }
  }
}
