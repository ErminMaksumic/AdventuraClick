import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user.model';
import { RouteStateService } from 'src/app/services/route-state.service';
import { SessionService } from 'src/app/services/session.service';
import { UserService } from 'src/app/services/user.service';
import { getUserId } from 'src/app/utils/jwt-decoder';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { imgToByte } from 'src/app/utils/transformImage';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css'],
})
export class ProfileEditComponent implements OnInit {
  groupData!: FormGroup;
  userId: number = 0;
  user: User = {};
  image: User = {};

  constructor(
    private builder: FormBuilder,
    private userService: UserService,
    private messageNotifications: MessageNotifications,
    private sessionService: SessionService,
    private routeStateService: RouteStateService
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.userId = getUserId();
    this.loadUser();
  }

  ngAfterViewInit(): void {
    this.sessionService.setItem('active-menu', 'home');
    this.routeStateService.add('home', 'profile', null, true);
    this.userService.changeActiveMenu('home');
  }

  initForm() {
    this.groupData = this.builder.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        password: [''],
        passwordConfirmation: [''],
        imageString: [null]
      },
      {
        validators: this.passwordMatchValidator,
      }
    );
  }

  passwordMatchValidator(formGroup: FormGroup) {
    return formGroup.get('password')?.value ===
      formGroup.get('passwordConfirmation')?.value
      ? null
      : { mismatch: true };
  }

  loadUser(search: string = '') {
    this.userService.getById(this.userId).subscribe({
      next: (result: User) => {
        this.user = result;
        this.fillInputs(this.user);
       
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }

  fillInputs(value: User) {
    this.groupData.get('firstName')?.patchValue(value.firstName);
    this.groupData.get('lastName')?.patchValue(value.lastName);

  }

  saveUser() {
    this.userService.profileUpdate(this.userId, this.groupData.value).subscribe({
      next: (result: User) => {
        this.user = result;
        this.messageNotifications.showSuccess(
          'User edited',
          'User edited successfully'
        );
        this.userService.updateUserImage(this.groupData.value.imageString);
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }

  async onUpload(event: any) {
    const byteArray = await imgToByte(
      event.files[0].objectURL.changingThisBreaksApplicationSecurity
    );
    const base64EncodedImage = btoa(
      String.fromCharCode(...new Uint8Array(byteArray))
    );
    this.groupData.patchValue({ imageString: base64EncodedImage });
  }
}
