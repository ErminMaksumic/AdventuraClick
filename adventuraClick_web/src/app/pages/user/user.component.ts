import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { transformImage } from 'src/app/utils/transformImage';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent {
  users: User[] = [];
  user!: User;
  searchQuery: string = '';
  userDialog: boolean = false;
  constructor(
    private userService: UserService,
    private messageNotifications: MessageNotifications
  ) {}

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(search: string = '') {
    this.userService
      .getAll({
        IncludeRole: true,
        username: search,
      })
      .subscribe({
        next: (result: User[]) => {
          this.users = result;
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }

  search(input: string) {
    this.loadUsers(input);
  }

  transformImageWrapper(image: string) {
    return transformImage(image);
  }

  editUser(travel: User) {
    this.user = { ...travel };
    this.userDialog = true;
  }

  saveUser(userValue: User) {
    this.userService.updateUserAccount(this.user.userId || 0, userValue).subscribe({
      next: (result: User) => {
        this.user = result;
        this.loadUsers();
        this.messageNotifications.showSuccess(
          'User edited',
          'User edited successfully'
        );
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
    this.users = [...this.users];
    this.userDialog = false;
    this.user = {};
  }

  deleteUser(userId: number) {
    this.userService.delete(userId).subscribe({
      next: () => {
        this.messageNotifications.showSuccess(
          'User deleted',
          'User deleted successfully'
        );
        this.loadUsers()
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }
}
