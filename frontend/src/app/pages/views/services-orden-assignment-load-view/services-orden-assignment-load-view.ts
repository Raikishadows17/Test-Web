import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ArmedTractView } from "../armed-tract-view/armed-tract-view";

@Component({
  selector: 'app-services-orden-assignment-load-view',
  imports: [CommonModule, FormsModule, ArmedTractView],
  templateUrl: './services-orden-assignment-load-view.html',
  styleUrl: './services-orden-assignment-load-view.css',
})
export class ServicesOrdenAssignmentLoadView {
  @Input() formData: any;

  onlyNumbers(event: any) {
    // Solo permite dígitos 0-9
    event.target.value = event.target.value.replace(/[^0-9]/g, '');
    if (event.target.value.length > 15) {
      event.target.value = event.target.value.substring(0, 15);
    }

    // Actualiza el ngModel
    const field = event.target.getAttribute('ng-reflect-name') || 'unknown';
    if (field in this.formData) {
      (this.formData as any)[field] = event.target.value;
    }
  }
  onCartaPorteSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.selectedCartaPorte = file.name;
    }
  }

  onBoletaTerminalSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.selectedBoletaTerminal = file.name;
    }
  }
  onDodaSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.selectedDoda = file.name;
    }
  }
  onChange() {
    if (this.formData.isFull || this.formData.isSocio) {
      // Por default: activar 2 contenedores y 4 equipos
      this.formData.dolly = '';
      this.formData.dollyColor = '#ffffff';
      this.formData.chasisSecundario = '';
      this.formData.containerType2 = '';
      this.formData.containerNumber2 = '';
      this.formData.chasisSecundarioColor = '#ffffff';
      this.formData.eqpmTracto = '';
      this.formData.eqpmChasisPrincipal = '';
      this.formData.eqpmDolly = '';
      this.formData.eqpmChasisSecundario = '';
    } else {
      // Limpiar campos adicionales si desmarcas Full
      this.formData.dolly = '';
      this.formData.dollyColor = '';
      this.formData.chasisSecundario = '';
      this.formData.containerType2 = '';
      this.formData.containerNumber2 = '';
      this.formData.chasisSecundarioColor = '';
      this.formData.eqpmTracto = '';
      this.formData.eqpmChasisPrincipal = '';
      this.formData.eqpmDolly = '';
      this.formData.eqpmChasisSecundario = '';
    }
  }
  onPedimentoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.selectedPedimento = file.name;
      console.log('Pedimento subido:', file.name);
    }
  }

  onNoSolicitarEquipoChange() {
    if (this.formData.noSolicitarEquipo) {
      this.formData.tractor = '';
      this.formData.chasisMain = '';
      this.formData.dolly = '';
      this.formData.chasisSecundario = '';
    }
  }
}
