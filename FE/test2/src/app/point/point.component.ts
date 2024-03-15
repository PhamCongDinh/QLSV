import { Component, OnInit } from '@angular/core';
import { PointService } from '../services/point.service';

@Component({
  selector: 'app-point',
  templateUrl: './point.component.html',
  styleUrl: './point.component.scss'
})
export class PointComponent implements OnInit {
  constructor(private point: PointService) { }
  ngOnInit(): void {
    this.hpofstu();
  }
  Coursedata: any[] = [];

  hpofstu() {
    this.point.pointbyid().subscribe(
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
}
