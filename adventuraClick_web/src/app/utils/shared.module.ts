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

@NgModule({
  declarations: [],
  imports: [],
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
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class SharedModule {}
