import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdditionalService } from 'src/app/models/additionalService.model';

@Component({
  selector: 'app-additional-services-modal',
  templateUrl: './additional-services-modal.component.html',
  styleUrls: ['./additional-services-modal.component.css'],
})
export class AdditionalServicesModalComponent {
  groupData!: FormGroup;
  formData = new FormData();
  @Output() onSave: EventEmitter<AdditionalService> = new EventEmitter();
  @Output() onClose: EventEmitter<AdditionalService> = new EventEmitter();
  @Input() additionalService: AdditionalService = {};

  constructor(private builder: FormBuilder) {}

  ngOnInit() {
    this.groupData = this.builder.group({
      addServiceId: [0],
      name: [
        '',
        { validators: [Validators.required, Validators.minLength(3)] },
      ],
      price: [0, { validators: [Validators.required] }],
    });

    this.fillInputs(this.additionalService);
  }

  hideDialog() {
    this.onClose.emit();
  }

  save() {
    if (this.groupData.valid) {
      this.onSave.emit(this.groupData.value);
    }
  }

  fillInputs(value: AdditionalService) {
    this.groupData.get('addServiceId')?.patchValue(value.addServiceId);
    this.groupData.get('name')?.patchValue(value.name);
    this.groupData.get('price')?.patchValue(value.price);
  }
}
