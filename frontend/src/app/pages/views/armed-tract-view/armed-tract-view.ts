import { CommonModule } from '@angular/common';
import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

type EquipoType = 'tracto' | 'chasisPrincipal' | 'dolly' | 'chasisSecundario';

@Component({
  selector: 'app-armed-tract-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './armed-tract-view.html',
  styleUrl: './armed-tract-view.css',
})
export class ArmedTractView {
  @Input() formData: any;
  equiposDisponibles: EquipoType[] = ['tracto', 'chasisPrincipal', 'dolly', 'chasisSecundario'];

  // Estado de selección (acumulativo)
  equiposSeleccionados: Record<EquipoType, boolean> = {
    tracto: false,           // por defecto activado
    chasisPrincipal: false,
    dolly: false,
    chasisSecundario: false
  };
  @ViewChild('canvasGrande') canvasGrande!: ElementRef<HTMLCanvasElement>;

  validatePedimento(event: any) {
    const value = event.target.value;
    if (value.length !== 15 || !/^[0-9]{15}$/.test(value)) {
      alert('Pedimento debe ser exactamente 15 dígitos numéricos');
      event.target.value = '';
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

  getHue(hexColor: string): number {
    if (!hexColor || hexColor === '#ffffff' || hexColor === '#000000') return 0;

    // Remueve # si existe
    hexColor = hexColor.replace('#', '');

    const r = parseInt(hexColor.substr(0, 2), 16) / 255;
    const g = parseInt(hexColor.substr(2, 2), 16) / 255;
    const b = parseInt(hexColor.substr(4, 2), 16) / 255;

    const max = Math.max(r, g, b);
    const min = Math.min(r, g, b);
    let h = 0;

    if (max === min) {
      h = 0;
    } else {
      const d = max - min;
      switch (max) {
        case r: h = (g - b) / d + (g < b ? 6 : 0); break;
        case g: h = (b - r) / d + 2; break;
        case b: h = (r - g) / d + 4; break;
      }
      h /= 6;
    }

    return Math.round(h * 360);
  }
  // Toggle: agregar/quitar figura y redibujar
  toggleEquipo(equipo: EquipoType) {
    this.equiposSeleccionados[equipo] = !this.equiposSeleccionados[equipo];
  }
  hayEquiposSeleccionados(): boolean {
  return Object.values(this.equiposSeleccionados).some(activo => activo);
}
  getLabelEquipo(equipo: string): string {
    switch (equipo) {
      case 'tracto': return 'Tracto';
      case 'chasisPrincipal': return 'Chasis Principal';
      case 'dolly': return 'Dolly';
      case 'chasisSecundario': return 'Chasis Secundario';
      default: return '';
    }
  }
  checkPatioExterno() {
    if (this.formData.loadStatus === 'patio_externo') {
      alert('Registrar motivo de patio externo');
    }
  }
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
  onNoSolicitarEquipoChange() {
    if (this.formData.noSolicitarEquipo) {
      this.formData.tractor = '';
      this.formData.chasisMain = '';
      this.formData.dolly = '';
      this.formData.chasisSecundario = '';
    }
  }

}
