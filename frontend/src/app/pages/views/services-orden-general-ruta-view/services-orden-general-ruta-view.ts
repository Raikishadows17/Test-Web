import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-services-orden-general-ruta-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './services-orden-general-ruta-view.html',
  styleUrl: './services-orden-general-ruta-view.css',
})
export class ServicesOrdenGeneralRutaView {
  @Input() formData: any;

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
}
