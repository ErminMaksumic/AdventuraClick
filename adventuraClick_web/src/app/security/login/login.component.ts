import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UserService } from '../../services/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Authorization } from 'src/app/utils/auth.interceptor';
import { MessageService } from 'primeng/api';
import { MessageNotifications } from 'src/app/utils/messageNotifications';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [MessageService]
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private service: UserService, private formBuilder: FormBuilder, private messageService: MessageService, private messageNotifications: MessageNotifications) {}
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
    this.service.login(username, password).subscribe({
      next: (result: Authorization) => {
        this.messageNotifications.showSuccess("Login success", "You'are logged in")     
       },
      error: (error) => {
        this.messageNotifications.showError("Login failed", "Please check your username and password")     
      }
    });
}
}
