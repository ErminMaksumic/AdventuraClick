import { Component, OnInit } from '@angular/core';
import { User, UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private service: UserService) {
    this.service.login().subscribe({
      next: (data: User) => {
        console.log('data', data);
      },
      error: (error) => {
        console.error('Error', error);
      },
    });
  }
  ngOnInit(): void {}
}
