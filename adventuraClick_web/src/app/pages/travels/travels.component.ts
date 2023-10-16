import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { TravelInformation } from 'src/app/models/travel-information.model';
import { Travel } from 'src/app/models/travel.model';
import { TravelService } from 'src/app/services/travel.service';

@Component({
  selector: 'table-products-demo',
  templateUrl: 'travels.component.html',
  styleUrls: ['travels.component.css'],
  providers: [MessageService, ConfirmationService],
  encapsulation: ViewEncapsulation.None,
})
export class TravelsComponent implements OnInit {
  travelDialog: boolean = false;
  travels!: Travel[];
  travel!: Travel;
  selectedProducts!: Travel[] | null;
  submitted: boolean = false;
  statuses!: any[];
  joinedDates: string = '';

  constructor(
    private travelService: TravelService,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.travelService
      .getAll({ IncludeTravelType: true, IncludeTravelInformation: true })
      .subscribe({
        next: (result: Travel[]) => {
          this.travels = result;
          console.log('this.travels', this.travels);
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
    this.statuses = [
      { label: 'INSTOCK', value: 'instock' },
      { label: 'LOWSTOCK', value: 'lowstock' },
      { label: 'OUTOFSTOCK', value: 'outofstock' },
    ];
  }

  openNew() {
    this.travel = {};
    this.submitted = false;
    this.travelDialog = true;
  }

  editProduct(product: Travel) {
    this.travel = { ...product };
    this.travelDialog = true;
  }

  // deleteProduct(product: Product) {
  //     this.confirmationService.confirm({
  //         message: 'Are you sure you want to delete ' + product.name + '?',
  //         header: 'Confirm',
  //         icon: 'pi pi-exclamation-triangle',
  //         accept: () => {
  //             this.products = this.products.filter((val) => val.id !== product.id);
  //             this.product = {};
  //             this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Deleted', life: 3000 });
  //         }
  //     });
  // }

  hideDialog() {
    this.travelDialog = false;
    this.submitted = false;
  }

  saveProduct() {
    this.submitted = true;

    if (this.travel.name?.trim()) {
      if (this.travel.travelId) {
        this.travels[
          this.findIndexById(this.travel.travelId?.toString() ?? '0')
        ] = this.travel;
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Product Updated',
          life: 3000,
        });
      } else {
        this.travel.travelId = Number(this.createId());
        this.travel.image = 'product-placeholder.svg';
        this.travels.push(this.travel);
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Product Created',
          life: 3000,
        });
      }

      this.travels = [...this.travels];
      this.travelDialog = false;
      this.travel = {};
    }
  }

  findIndexById(id: string): number {
    let index = -1;
    for (let i = 0; i < this.travels.length; i++) {
      if (this.travels[i].travelId === Number(id)) {
        index = i;
        break;
      }
    }

    return index;
  }

  createId(): string {
    let id = '';
    var chars =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }

  getSeverity(status: string) {
    switch (status) {
      case 'INSTOCK':
        return 'success';
      case 'LOWSTOCK':
        return 'warning';
      case 'OUTOFSTOCK':
        return 'danger';
    }

    return 'danger';
  }

  transformImage(image: string) {
    return 'data:image/jpeg;base64,' + image;
  }

  displayDates(data: TravelInformation[]) {
    return data.map(item => {
        let date = new Date(item.departureTime!);
        let year = date.getFullYear();
        let month = String(date.getMonth() + 1).padStart(2, '0');
        let day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    }).join(', ');
}
}
