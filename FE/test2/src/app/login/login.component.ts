import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent {
  // data: any = {};
  constructor(private auth: AuthService, private router: Router) { }
  login(formdata: any) {
    if (formdata.valid) {
      const data = {
        "id": formdata.value.id,
        "password": formdata.value.password
      };
      console.log(data);
      this.auth.login(data).subscribe(
        Response => {
          if (Response.message == "student") {
            localStorage.setItem('studentId', data.id);
            alert("Đăng nhập thành công");
            this.router.navigate(['/Home']);
          }
          else if (Response.message == "teacher") {
            localStorage.setItem('teacherId', data.id);
            alert("Đăng nhập thành công");
            this.router.navigate(['/hometeacher']);
          }

        },
        error => {
          alert("Đăng nhập thất bại\n mã sinh viên hoặc mật khẩu không đúng")
        }
      );
    }




  }
}
