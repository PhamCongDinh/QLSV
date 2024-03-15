import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  constructor(private auth: AuthService) { }
  register(formdata: any) {
    if (formdata.valid) {
      if (formdata.value.password !== formdata.value.conficpass) {
        // Reset giá trị và thêm class error
        formdata.controls['password'].reset();
        formdata.controls['conficpass'].reset();
        formdata.controls['password'].setErrors({ 'incorrect': true });
        formdata.controls['conficpass'].setErrors({ 'incorrect': true });
        alert("conficpass not true");
        return;
      }

      const data = {
        "id": formdata.value.id,
        "username": formdata.value.studentname,
        "email": formdata.value.email,
        "password": formdata.value.password,
        "classes": formdata.value.classes
      };

      console.log(data);
      this.auth.register(data).subscribe(
        response => {
          alert("Đăng ký thành công");
        },
        error => {
          alert("Đăng ký thất bại");
        }
      );
    }
  }

}
