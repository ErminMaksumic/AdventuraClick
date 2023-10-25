import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { transformImage } from 'src/app/utils/transformImage';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  @Input() currentRoute: string = '';
  @Input() user: User = {};
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.userImage$.subscribe((newImageUrl) => {
      if (newImageUrl) {
        this.user.image = newImageUrl;
      }
    });
    this.userService.username$.subscribe((newUsername) => {
      if (newUsername) {
        this.user.username = newUsername;
      }
    });
  }

  transformImageWrapper() {
    return transformImage(this.user.image || '');
  }
}
