import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
    providedIn: 'root'
  })
export class MessageNotifications {
    constructor(private messageService: MessageService) {}

    showSuccess(summary: string, detail: string) {
        console.log("success");
        this.messageService.add({ severity: 'success', summary: summary, detail: detail });
    }
}
