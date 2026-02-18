import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-doc-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment-doc-view.html',
  styleUrl: './equipment-doc-view.css',
})
export class EquipmentDocView {
  @Input() formData: any;
  selectedFacturaCompra = '';
  selectedTituloCompra = '';
  selectedDocSeguro = '';

  // Métodos para selección de archivos
  onFacturaCompraSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFacturaCompra = file.name;
    }
  }

  onTituloCompraSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedTituloCompra = file.name;
    }
  }

  onDocSeguroSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedDocSeguro = file.name;
    }
  }
}
