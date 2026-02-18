import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-services-orden-assignment-load-view',
  imports: [CommonModule, FormsModule],
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
  onFullChange() {
    if (this.formData.isFull) {
      // Por default: activar 2 contenedores y 4 equipos
      this.formData.dolly = '';
      this.formData.dollyColor = '#ffffff';
      this.formData.chasisSecundario = '';
      this.formData.containerType2 = '';
      this.formData.containerNumber2 = '';
      this.formData.chasisSecundarioColor = '#ffffff';
    } else {
      // Limpiar campos adicionales si desmarcas Full
      this.formData.dolly = '';
      this.formData.dollyColor = '';
      this.formData.chasisSecundario = '';
      this.formData.containerType2 = '';
      this.formData.containerNumber2 = '';
      this.formData.chasisSecundarioColor = '';
    }
  }
  onPedimentoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.selectedPedimento = file.name;
      console.log('Pedimento subido:', file.name);
    }
  }
  onEsSocioChange() {
  if (this.formData.isSocio) {
    // Si es socio, ocultamos los campos que no se necesitan
    // Puedes limpiar los valores si quieres (opcional)
    this.formData.eqpmTracto = '';
    this.formData.eqpmChasisPrincipal = '';
    this.formData.eqpmDolly = '';
    this.formData.eqpmChasisSecundario = '';
  }
  // Si desmarca el checkbox, no hacemos nada (los campos vuelven a ser visibles por *ngIf)
}
checkPatioExterno() {
  if (this.formData.loadStatus === 'patio_externo') {
    alert('Registrar motivo de patio externo');
  }
}
validateContainer(event: any) {
  const value = event.target.value.toUpperCase();
  const pattern = /^[A-Z]{4}[0-9]{7}$/;
  if (value && !pattern.test(value)) {
    alert('Formato inválido: 4 letras + 7 números (ej: CAUX1234567)');
    event.target.value = '';
  }
}
validatePedimento(event: any) {
  const value = event.target.value;
  if (value.length !== 15 || !/^[0-9]{15}$/.test(value)) {
    alert('Pedimento debe ser exactamente 15 dígitos numéricos');
    event.target.value = '';
  }
}
onNoSolicitarEquipoChange() {
  if (this.formData.noSolicitarEquipo) {
    // Limpiar campos de equipo (para que no queden valores viejos)
    // Opcional: limpiar también colores si los tienes
    this.formData.tractor = '';
    this.formData.chasisMain = '';
    this.formData.dolly = '';
    this.formData.chasisSecundario = '';
  }
  // Si se desmarca, no necesitas hacer nada (el usuario puede volver a seleccionar)
}
}
