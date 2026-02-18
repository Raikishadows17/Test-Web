import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-maintenance-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment-maintenance-view.html',
  styleUrl: './equipment-maintenance-view.css',
})
export class EquipmentMaintenanceView {
  @Input() formData: any;
  recibosCount = 0;
  boletaCount = 0;
  cartaPorteCount = 0;
  fotosRevisionCount = 0;

  // Métodos de selección (contadores simples)
  onRecibosRelacionesSelected(event: any) {
    this.recibosCount = event.target.files.length;
  }
  onBoletaTerminalSelected(event: any) {
    this.boletaCount = event.target.files.length;
  }

  onCartaPorteSelected(event: any) {
    this.cartaPorteCount = event.target.files.length;
  }

  onFotosRevisionSelected(event: any) {
    this.fotosRevisionCount = event.target.files.length;
  }
}
