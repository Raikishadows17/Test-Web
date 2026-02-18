import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contract-rates-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './contract-rates-view.html',
  styleUrl: './contract-rates-view.css',
})
export class ContractRatesView {
  @Input() formData: any;

  // Métodos para rutas
  addRuta() {
    this.formData.rutas.push({
      origen: '',
      destino: '',
      tipoUnidad: '',
      tarifa: 0
    });
  }
  removeRuta(index: number) {
    this.formData.rutas.splice(index, 1);
  }

  editRuta(index: number) {
    // Puedes implementar edición en línea o modal
    alert('Editar ruta ' + (index + 1) + ' (implementar funcionalidad)');
  }
}
