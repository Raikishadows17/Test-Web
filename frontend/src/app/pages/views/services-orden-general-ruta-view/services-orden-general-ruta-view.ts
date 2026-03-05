import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-services-orden-general-ruta-view',
  imports: [CommonModule, FormsModule, MatAutocompleteModule, MatInputModule ],
  templateUrl: './services-orden-general-ruta-view.html',
  styleUrl: './services-orden-general-ruta-view.css',
})
export class ServicesOrdenGeneralRutaView {
  @Input() formData: any;
  @Input() options: any;

   filteredRoutes: { origen: string; destino: string; urlMapa: string }[] = [];

  ngOnInit() {
    const now = new Date();
    this.formData.daterequest = this.formatDate(now);
  }
  formatDate(date: Date): string {
  const pad = (n: number) => n.toString().padStart(2, '0');

  return `${date.getFullYear()}-${pad(date.getMonth() + 1)}-${pad(date.getDate())}`;
}
  addDestino() {
    this.formData.destinations.push({ place: '', address: '', mapUrl: '' });
  }

  removeDestino(index: number) {
    if (index > 0) { // Nunca elimines el primero
      this.formData.destinations.splice(index, 1);
    }
  }
  formatTime(event: any) {
    let value = event.target.value.replace(/[^0-9:]/g, ''); // Solo números y :

    // Limita a 5 caracteres (HH:MM)
    if (value.length > 5) value = value.substring(0, 5);

    // Agrega : automáticamente después de las 2 primeras cifras
    if (value.length === 2 && !value.includes(':')) {
      value += ':';
    }

    // Valida rango de horas (00-23) y minutos (00-59)
    const parts = value.split(':');
    if (parts.length > 1) {
      let hours = parts[0];
      let minutes = parts[1];

      // Horas: máximo 23
      if (hours.length === 2 && Number(hours) > 23) {
        hours = '23';
      }

      // Minutos: máximo 59
      if (minutes.length === 2 && Number(minutes) > 59) {
        minutes = '59';
      }

      value = hours + (minutes ? ':' + minutes.substring(0, 2) : ':');
    }

    event.target.value = value;
    this.formData.estimatedTime = value;
  }
  onSearch(term: string):void {
    const query = term.toLowerCase();
    this.filteredRoutes = this.formData.options.routes.filter(
      (r: any) =>
        r.origen.toLowerCase().includes(query) ||
        r.destino.toLowerCase().includes(query)
    );
  }
  selectRoute(route: { origen: string; destino: string; urlMapa: string }): void {
    this.formData.route.selectedRoute = route;
  }

  displayRoute(route: any): string {
    return route ? `${route.origen} → ${route.destino}` : '';
  }

}
