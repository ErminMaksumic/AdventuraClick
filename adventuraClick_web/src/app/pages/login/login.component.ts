import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { Router } from '@angular/router';
import { SecurityService } from 'src/app/services/security.service';
import { AuthorizationResponse } from 'src/app/models/auth-response.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [MessageService],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private securityService: SecurityService,
    private formBuilder: FormBuilder,
    private messageNotifications: MessageNotifications,
    private router: Router
  ) {}
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
      this.login(username, password);
    }
  }

  login(username: string, password: string) {
    this.securityService.login({ username, password }).subscribe({
      next: (result: AuthorizationResponse) => {
        this.messageNotifications.showSuccess(
          'Login success',
          "You'are logged in"
        );
        this.router.navigate(['home']);
      },
      error: () => {
        this.messageNotifications.showError(
          'Login failed',
          'Please check your username and password'
        );
      },
    });
  }
}
