import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { User, UserService } from '../../services/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Authorization } from 'src/app/utils/auth.interceptor';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private service: UserService, private formBuilder: FormBuilder) {}
  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm?.valid) {
      const username = this.loginForm.get('username')?.value;
      const password = this.loginForm.get('password')?.value;
      Authorization.username = username;
      Authorization.password = password;
      this.login(username, password);
    }
  }

  login(username: string, password: string) {
    return this.service.login(username, password).subscribe({
      next: (data: User) => {
        console.log('data', data);
      },
      error: (error: Error) => {
        console.error('Error', error);
      },
    });
  }
}
