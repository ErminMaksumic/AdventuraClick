import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Travel } from 'src/app/models/travel.model';
import { Role, User } from 'src/app/models/user.model';
import { RoleService } from 'src/app/services/role.service';
import { transformImage } from 'src/app/utils/transformImage';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrls: ['./user-modal.component.css'],
})
export class UserModalComponent {
  @Input() user: User = {};
  submitted: boolean = false;
  groupData!: FormGroup;
  formData = new FormData();
  roles: Role[] = [];
  @Output() onSave: EventEmitter<Travel> = new EventEmitter();
  @Output() onClose: EventEmitter<Travel> = new EventEmitter();

  constructor(private builder: FormBuilder, private roleService: RoleService) {}

  ngOnInit() {
    this.groupData = this.builder.group({
      username: [
        '',
        { validators: [Validators.required, Validators.minLength(3)] },
      ],
      firstName: ['', { validators: [Validators.required] }],
      lastName: ['', { validators: [Validators.required] }],
      role: [{}, { validators: [Validators.required] }],
    });

    this.getRoles();
    this.fillInputs(this.user);
  }

  save() {
    this.groupData.value.roleId = this.groupData.value.role.roleId;
    if (this.groupData.valid) {
      this.submitted = true;
      this.onSave.emit(this.groupData.value);
    }
  }

  hideDialog() {
    this.onClose.emit();
  }

  fillInputs(value: User) {
    this.groupData.get('username')?.patchValue(value.username);
    this.groupData.get('firstName')?.patchValue(value.firstName);
    this.groupData.get('lastName')?.patchValue(value.lastName);
    this.groupData.get('role')?.patchValue(value.role);
  }

  transformImageWrapper(image: string) {
    return transformImage(image);
  }

  async getRoles() {
    this.roleService.getAll().subscribe({
      next: (result: Role[]) => {
        this.roles = result;
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }
}
