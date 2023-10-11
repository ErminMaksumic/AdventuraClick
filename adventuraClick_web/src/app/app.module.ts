import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgParticlesModule } from 'ng-particles';
import { AppComponent } from './app.component';
import { LoginComponent } from './security/login/login.component';
import { AppRoutingModule } from './app.routing.module';
import { ParticlesComponent } from './security/login/particles/particles.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './utils/auth.interceptor';
import { ButtonModule } from 'primeng/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';
import { MessageService } from 'primeng/api';
import { MessageNotifications } from './utils/messageNotifications';
import { ToastModule } from 'primeng/toast';

@NgModule({
  declarations: [AppComponent, LoginComponent, ParticlesComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgParticlesModule,
    HttpClientModule,
    ButtonModule,
    ReactiveFormsModule,
    FormsModule,
    CardModule,
    InputTextModule,
    PasswordModule,
    ToastModule,
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    MessageService,
    MessageNotifications,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
