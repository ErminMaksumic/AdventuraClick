import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './utils/auth.interceptor';
import { MessageService } from 'primeng/api';
import { MessageNotifications } from './utils/messageNotifications';
import { LoginModule } from './pages/login/login.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from './utils/shared.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    LoginModule,
    SharedModule
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
