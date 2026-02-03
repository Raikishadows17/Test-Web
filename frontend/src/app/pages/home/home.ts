import { Component } from "@angular/core";
import { DatePipe } from "@angular/common";
import { Sidebar } from "../../components/sidebar/sidebar";
import { RouterOutlet } from "@angular/router";
import { AuthService } from "../../auth/auth.service";
import { LoadingService } from "../../components/loading/loading.service";

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [Sidebar, DatePipe, RouterOutlet],
  templateUrl: './home.html',
  styleUrls: ['./home.css'],
})

export class HomePage {
  fecha: Date =  new Date();
  usertype = "Admin";
  name = "Fernando Gonzalez";


  containerTheme = false;
  inputsTheme = false;

  private intervalId?: number;

  constructor(
    private auth: AuthService,
    private loading: LoadingService
  ) {
    const token = localStorage.getItem('token');

    console.log("TOKEN AL ABRIR HOME:", token);
  }

  ngOnInit(): void{
    // Simulación de carga
    this.loading.show();
    setTimeout(() => {
      this.loading.hide();
    }, 1200);
    /*  await new Promise(resolve => setTimeout(resolve, 1200));
    this.loading.hide();*/

    // Actualizar la fecha cada segundo
    this.intervalId = setInterval(() => {
      this.fecha = new Date();
    }, 1000);
  }
  ngOnDestroy(): void {
    // Limpiar el interval para evitar memory leaks
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }

  navigateTo(label: string) {

    if (label === 'Cerrar Sesion') {
      this.auth.logout();
      return;
    }
  }
  toggleContainerTheme() {
    this.containerTheme = !this.containerTheme;
  }

  toggleInputsTheme() {
    this.inputsTheme = !this.inputsTheme;
  }
}
