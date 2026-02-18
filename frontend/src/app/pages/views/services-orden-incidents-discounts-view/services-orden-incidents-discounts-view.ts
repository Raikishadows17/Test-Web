import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-services-orden-incidents-discounts-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './services-orden-incidents-discounts-view.html',
  styleUrl: './services-orden-incidents-discounts-view.css',
})
export class ServicesOrdenIncidentsDiscountsView {
  @Input() formData: any;

  onTallerComprobanteSelected(event: any) {
  const file = event.target.files[0];
  if (file) {
    // Guardamos el nombre del archivo en formData para mostrarlo
    this.formData.selectedTallerComprobante = file.name;

    // Opcional: puedes guardar el archivo completo si lo necesitas para enviar al backend
    // this.formData.tallerComprobanteFile = file; // ← descomenta si quieres guardar el objeto File

    console.log('Comprobante de taller subido:', file.name, 'Tamaño:', file.size, 'Tipo:', file.type);

    // Opcional: validación básica de tamaño o tipo
    if (file.size > 5 * 1024 * 1024) { // 5 MB máximo, por ejemplo
      alert('El archivo es demasiado grande. Máximo 5 MB.');
      this.formData.selectedTallerComprobante = '';
      event.target.value = ''; // limpia el input
    }
  }
}
}
