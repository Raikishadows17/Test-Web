import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-service-orders-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './service-orders-form.html',
  styleUrl: './service-orders-form.css',
})
export class ServiceOrdersForm {
  activeTab = 1;
  selectedCartaPorte = '';
  selectedBoletaTerminal = '';
  selectedDoda = '';
  // Datos del formulario (puedes separarlos por tab si quieres)
  formData = {
    folio: 'SERV-2026-001',
    client: '',
    tripType: '',
    status: '',
    operator: '',
    tractor: '',
    trailer: '',
    containerNumber: '',
    containerType: '',
    loadStatus: '',
    weight: '',
    seal1: '',
    seal2: '',
    pedimento: '',
    isFull: false,
    originPlace: '',
    originAddress: '',
    destinationPlace: '',
    destinationAddress: '',
    estimatedKm: '',
    estimatedTime: '',
    requiresOvernight: false,
    solicitud: '',
    programada: '',
    citaCarga: '',
    citaDescarga: '',
    expenses: [] as { date: string, concept: string, amount: number, paymentMethod: string, evidence: string }[],
    destinations: [{ place: '', address: '', mapUrl: '' }]

  };
  newExpense = {
    date: new Date().toLocaleDateString('es-MX'),
    concept: '',
    amount: 0,
    paymentMethod: '',
    evidence: ''  // Puedes guardar nombre de archivo o URL después de subir
  };
  // Opciones de selects
  clients = ['Walmart', 'Samsung Lázaro Cárdenas', 'Proveedor Automotriz'];
  tripTypes = ['Local', 'Foráneo'];
  statuses = ['Programado', 'En Tránsito', 'En Planta', 'Finalizado', 'Facturado'];
  operators = ['Juan Pérez (Disponible)', 'Luis López (Disponible)', 'Ana Gómez'];
  tractors = ['ECO-55 (Kenworth)', 'ECO-90 (Freightliner)'];
  trailers = ['Chasis 40ft - CH01', 'Plana - PL02'];
  containerTypes = ['20 DC', '40 DC', '40 HC', 'Refrigerado'];
  loadStatuses = ['Lleno', 'Vacío'];
  expenseConcepts = ['Diesel', 'Casetas (Tag)', 'Maniobra', 'Talachas', 'Estadia', 'Comidas'];
  paymentMethods = ['Efectivo', 'Transferencia', 'Tag', 'Vale'];
  placesOrigin = ['Puerto Lázaro Cárdenas', 'Patio Regulador', 'Bodega Cliente'];
  placesDestination = ['CDMX Pantaco', 'Planta Querétaro', 'Guadalajara'];

  addDestino() {
    this.formData.destinations.push({ place: '', address: '', mapUrl: '' });
  }

  removeDestino(index: number) {
    if (index > 0) { // Nunca elimines el primero
      this.formData.destinations.splice(index, 1);
    }
  }
  // Cambiar tab
  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
  // Agregar gasto (para tab 3)
  addExpense() {
    if (this.newExpense.concept && this.newExpense.amount > 0) {
      this.formData.expenses.push({ ...this.newExpense });

      // Limpia el formulario para el siguiente ingreso
      this.newExpense = {
        date: new Date().toLocaleDateString('es-MX'),
        concept: '',
        amount: 0,
        paymentMethod: '',
        evidence: ''
      };

      console.log('Gasto agregado:', this.formData.expenses);
    } else {
      alert('Completa Concepto y Monto para agregar el gasto');
    }
  }

  onSubmit() {
    console.log('Orden de servicio enviada:', this.formData);
    alert('Orden guardada con éxito');
  }
  onCartaPorteSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedCartaPorte = file.name;
    }
  }

  onBoletaTerminalSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedBoletaTerminal = file.name;
    }
  }

  onDodaSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedDoda = file.name;
    }
  }
  get totalExpenses(): number {
    return this.formData.expenses.reduce((sum, exp) => sum + Number(exp.amount), 0);
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
}
