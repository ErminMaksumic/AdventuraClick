import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Travel } from 'src/app/models/travel.model';

@Component({
  selector: 'app-travel-modal',
  templateUrl: './travel-modal.component.html',
  styleUrls: ['./travel-modal.component.css'],
})
export class TravelModalComponent {
  @Input() travel: Travel = {};
  submitted: boolean = false;
  groupData!: FormGroup;
  formData = new FormData();
  @Output() onSave: EventEmitter<Travel> = new EventEmitter();
  @Output() onClose: EventEmitter<Travel> = new EventEmitter();

  constructor(private builder: FormBuilder) {}

  ngOnInit() {
    this.groupData = this.builder.group({
      name: [
        '',
        { validators: [Validators.required, Validators.minLength(3)] },
      ],
      price: [0, { validators: [Validators.required] }],
      numberOfNights: [0, { validators: [Validators.required] }],
    });

    this.fillInputs(this.travel);
  }

  saveProduct() {
    console.log('hej', this.groupData.value);
    if (this.groupData.valid) {
      this.submitted = true;
      this.onSave.emit(this.groupData.value);
    }
  }

  hideDialog() {
    this.onClose.emit();
  }

  fillInputs(value: Travel) {
    this.groupData.get('name')?.patchValue(value.name);
    this.groupData.get('price')?.patchValue(value.price);
    this.groupData.get('numberOfNights')?.patchValue(value.numberOfNights);
  }
}
