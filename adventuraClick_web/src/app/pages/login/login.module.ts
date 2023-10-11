import { NgModule } from '@angular/core';
import { NgParticlesModule } from 'ng-particles';
import { PasswordModule } from 'primeng/password';
import { AppComponent } from 'src/app/app.component';
import { LoginComponent } from './login.component';
import { ParticlesComponent } from './particles/particles.component';
import { SharedModule } from 'src/app/utils/shared.module';
import { LoginRoutingModule } from './login.routing.module';

@NgModule({
  declarations: [LoginComponent, ParticlesComponent],
  imports: [
    NgParticlesModule,
    PasswordModule,
    SharedModule,
    LoginRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class LoginModule {}
