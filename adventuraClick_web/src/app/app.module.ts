import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './utils/auth.interceptor';
import { MessageService } from 'primeng/api';
import { MessageNotifications } from './utils/messageNotifications';
import { LoginModule } from './pages/login/login.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from './utils/shared.module';
import { TravelsModule } from './pages/travels/travels.module';
import { FooterComponent } from './pages/footer/footer.component';
import { HeaderComponent } from './pages/header/header.component';
import { ReservationsModule } from './pages/reservations/reservations.module';
import { RatingsModule } from './pages/ratings/ratings.module';
import { UsersModule } from './pages/user/users.module';
import { AdditionalServicesModule } from './pages/additional-services/additionalServices.module';

@NgModule({
  declarations: [AppComponent, FooterComponent, HeaderComponent],
  imports: [
    LoginModule,
    SharedModule,
    TravelsModule,
    ReservationsModule,
    RatingsModule,
    UsersModule,
    AdditionalServicesModule
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
