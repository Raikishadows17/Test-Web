import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-catalog-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment-catalog-form.html',
  styleUrl: './equipment-catalog-form.css',
})
export class EquipmentCatalogForm {
  activeTab = 1;
  selectedPhotoName = '';
  selectedPolicyName = '';
  selectedFacturaCompra = '';
  selectedTituloCompra = '';
  selectedDocSeguro = '';
  recibosCount = 0;
  boletaCount = 0;
  cartaPorteCount = 0;
  fotosRevisionCount = 0;

  formData = {
    economicNumber: '',
    unitType: '',
    federalPlates: '',
    fuelType: '',
    brandModel: '',
    year: '',
    isSocialProvider: false,
    isDoubleTrailer: false,
    ejn: '',
    color: '',
    platePosition: '',
    circulationCardExpiration: '',
    insuranceExpiration: '',
    mechanicalVerification: '',
    verificationStatus: '',
    purchaseInvoice: null,
    status: '',
    maintenanceNotes: '',
    colorPicker: '',
    descriptionFull: '',
    habilitadoForaneo: false,
    esSocioProveedor: false,
    equipoVendidoSinPapeles: false,
    unidadRotulada: false,
    dieselCapacity: null,
    trailerCapacity: null,
    imagenReferencia: '',
    colorDistintivo: '#0000ff',
    ejes: '',
    estudioMecanicoActivo: false,
    fechaEstudioMecanico: '',
    vigenciaEstudioMecanico: '',
    hologramasActivo: false,
    fechaHologramas: '',
    vigenciaHologramas: '',
    vigenciaVerificacion: '',
    vencimientoPoliza: '',
    folioPoliza: '',
    estatusOperativo: '',
    rojoFuncionalBloqueo: false,
    tipoMantenimiento: '',
    fechaIngresoTaller: '',
  };
  // Opciones para selects (nativas)
  unitTypes = ['Tracto', 'Dolly', 'Chasis 20°', 'Chasis 40°', 'Plana', 'Caja Seca'];
  fuelTypes = ['Diésel', 'Gasolina', ' Hibrido', 'Gas LP'];
  years = Array.from({ length: 20 }, (_, i) => 2026 - i); // 2005-2025
  states = ['Vigente', 'Vencida', 'Próxima a vencer'];
  positions = ['Carril 1', 'Carril 2', 'Taller 3', 'Salida'];
  axles = ['2', '3', '4+'];
  currentStatus = ['Disponible', 'En Ruta', 'Mantenimiento Preventivo', 'Mantenimiento Correctivo', 'Rojo (no circula)', 'Baja'];
  tiposMantenimiento = ['Preventivo', 'Correctivo', 'Revisión General', 'Otro'];

  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
  //simulamos el guardar
  onSubmit() {
    if (this.formData.economicNumber && this.formData.unitType) {
      console.log('Formulario enviado:', this.formData);
      alert('Formulario enviado con éxito.');
    } else {
      alert('Por favor, complete los campos obligatorios.');
    }
  }
  //simular subir archivo
  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      console.log('Archivo seleccionado:', file.name);
    }
  }
  onPhotoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      console.log('Foto seleccionada:', file.name);
      this.selectedPhotoName = file.name;
    }
  }
  onPolicyPdfSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      console.log('PDF Póliza seleccionado:', file.name);
      this.selectedPolicyName = file.name;
      // Aquí puedes validar que sea PDF o subirlo
    }
  }
  onlyLetters(event: KeyboardEvent) {
    const pattern = /[A-Za-zÁÉÍÓÚáéíóúÑñ\s]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
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
