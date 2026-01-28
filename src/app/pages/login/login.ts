import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../../auth/auth.service";

import {} from '../../app.routes';
import { LoadingService } from "../../components/loading/loading.service";

@Component({
  selector: 'app-login-page',
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
})
export class LoginPage{
  email: string = '' ;
  password: string = "" ;
  errorMessage: string = '';
  tenantId: string = '';


  constructor(
    private router: Router,
    private auth: AuthService,

  ){
  }
  async handleLogin() {
    this.errorMessage = '';

    const ok =  await this.auth.login(this.email, this.password);
    if (ok) {
      this.router.navigate(['/dashboard']);
    } else {
      this.errorMessage = 'Correo o contraseña incorrectos.';
    }
  }
}
