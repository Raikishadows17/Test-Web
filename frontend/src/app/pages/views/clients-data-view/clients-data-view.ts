import { CommonModule } from '@angular/common';
import { Component, input, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-clients-data',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './clients-data-view.html',
  styleUrl: './clients-data-view.css',
})
export class ClientsDataView {
  selectedConstancia = '';
  @Input() formData: any;

  // Bloquea caracteres no permitidos en RFC mientras se escribe
  onlyRfcChars(event: KeyboardEvent) {
    const pattern = /[A-Z0-9]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  validateRfc() {
    const rfc = this.formData.rfc?.trim().toUpperCase();
    if (!rfc) return;

    const rfcRegex = /^[A-Z]{4}[0-9]{6}[A-Z0-9]{3}$/;
    if (!rfcRegex.test(rfc)) {
      alert('RFC inválido: debe ser 4 letras + 6 números + 3 alfanuméricos (13 caracteres)');
    }
  }
  formatRfc(event: any) {
    let value = event.target.value.toUpperCase().replace(/[^A-Z0-9]/g, ''); // Solo A-Z y 0-9
    if (value.length > 13) value = value.substring(0, 13);
    event.target.value = value;
    this.formData.rfc = value;
  }
  onlyLettersWithSpaces(event: KeyboardEvent) {
    const pattern = /[A-Za-zÁÉÍÓÚáéíóúÑñ\s]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  onConstanciaSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedConstancia = file.name;
    }
  }
}

