import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PasswordModule } from 'primeng/password';
import { AppComponent } from 'src/app/app.component';
import { AppRoutingModule } from '../app.routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule } from 'primeng/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../pages/sidebar/sidebar.component';
import { SidebarModule } from 'primeng/sidebar';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { TagModule } from 'primeng/tag';
import { ToolbarModule } from 'primeng/toolbar';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { DropdownModule } from 'primeng/dropdown';
import { StepsModule } from 'primeng/steps';
import { PickListModule } from 'primeng/picklist';
import { FileUploadModule } from 'primeng/fileupload';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [SidebarComponent],
  imports: [SidebarModule, ButtonModule, CommonModule, RouterModule],
  exports: [
    PasswordModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ButtonModule,
    ReactiveFormsModule,
    FormsModule,
    CardModule,
    InputTextModule,
    ToastModule,
    BrowserAnimationsModule,
    CommonModule,
    SidebarModule,
    SidebarComponent,
    RouterModule,
    TableModule,
    TagModule,
    ToolbarModule,
    DialogModule,
    ConfirmDialogModule,
    InputNumberModule,
    ReactiveFormsModule,
    InputTextareaModule,
    DropdownModule,
    StepsModule,
    FileUploadModule,
    PickListModule,
    CalendarModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class SharedModule {}
