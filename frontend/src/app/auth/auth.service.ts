import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { firstValueFrom } from "rxjs";
import { Router } from "@angular/router";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: "root"
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  async login(UserName: string, password: string): Promise<boolean> {

    try {
      const body = { UserName, password };

      const res: any = await firstValueFrom(
        this.http.post(`${environment.apiURL}/api/Auth/Login`, body, {
          headers: { TenantId: 'Valmarq','X-API-KEY': '93c0f156-0173-449f-a290-d17a458918a6' }//TODO no debería esta aqui configurado, por que se requiere para todas las llamadas.
        })
      );
      const data = res.Data;

      if (!data) {
        console.error("No viene Data en la respuesta:", res);
        return false;
      }

      localStorage.setItem('token', data.token);
      localStorage.setItem('tokenExpiration', data.tokenExpiration);
      localStorage.setItem('user', JSON.stringify(data.usuario));

      return true;

    } catch (err) {
      console.error("Login error:", err);
      return false;
    }
  }

  getToken() {
    return localStorage.getItem("token");
  }
  logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    localStorage.removeItem("tokenExpiration");
    alert("Sesión cerrada correctamente");
    this.router.navigate(['/login']);
  }
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

}

