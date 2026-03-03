import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EquipmentGeneralView } from '../../views/equipment-general-view/equipment-general-view';
import { EquipmentVisualPhotoView } from "../../views/equipment-visual-photo-view/equipment-visual-photo-view";
import { EquipmentService } from '../../catalogs/equipment/equipment.service'; // ajusta la ruta


@Component({
  selector: 'app-equipment-catalog-form',
  imports: [CommonModule, FormsModule, EquipmentGeneralView, EquipmentVisualPhotoView],
  templateUrl: './equipment-catalog-form.html',
  styleUrl: './equipment-catalog-form.css',
  
})
export class EquipmentCatalogForm {
  isEditMode = false;
  equipmentId: number | null = null;
  constructor(private route: ActivatedRoute,private equipmentService: EquipmentService) { }

  activeTab = 1;
  selectedPhotoName = '';
  selectedPolicyName = '';

  formData: any = {
    economicNumber: '',
    plates: '',
    serialNumber: '',
    brandName: '',
    equipTypeId: null,
    terminalId: null,
    tripTypeId: null,
    labeledUnit: false,
    availablePartners: false,
    dieselCapacity: null,
    towingCapacity: null,
    color: '#0000ff',

    // Campos derivados de objetos anidados (no vienen directo de la API)
    unitType: '',
    unitTypeDescr: '',
    terminalName: '',
    tripTypeName: '',
    statusName: '',
    habilitadoForaneo: false,

    // Campos que aún no existen en la API pero usas en el form
    year: '',
    fuelType: '',
    ejes: '',
    descriptionFull: '',
    unidadRotulada: false,
    esSocioProveedor: false,
    equipoVendidoSinPapeles: false,
    imagenReferencia: '',
    colorDistintivo: '#0000ff',
    platePosition: '',
    estatusOperativo: '',
    rojoFuncionalBloqueo: false,
    tipoMantenimiento: '',
    fechaIngresoTaller: '',
    estudioMecanicoActivo: false,
    fechaEstudioMecanico: '',
    vigenciaEstudioMecanico: '',
    hologramasActivo: false,
    fechaHologramas: '',
    vigenciaHologramas: '',
    vigenciaVerificacion: '',
    vencimientoPoliza: '',
    folioPoliza: '',

    fechaDocumentoSeguro: '',
    vigenciaDocumentoSeguro:'',

    options: {
      unitTypes: ['Tractocamión', 'Chasis', 'Dolly', 'Caja Seca', 'Plataforma'], // se puede obtener
      years: Array.from({ length: 30 }, (_, i) => 2025 - i),
      fuelTypes: ['Diésel', 'Gasolina', 'Gas Natural'], // No se necesita
      axles: ['2', '3', '4', '5', '6'],
      positions: ['Patio A', 'Patio B', 'Patio C', 'En ruta'],
      currentStatus: ['Disponible', 'En servicio', 'En mantenimiento', 'Fuera de servicio'], //NO SE NECESITA, SE CREA COMO DISPONIBLE POR DEFAULT
      typemaintenance: ['Preventivo', 'Correctivo', 'Mayor'] //NO SE NECESITA
    },
  };
  

  ngOnInit() {
    this.equipmentId = Number(this.route.snapshot.paramMap.get('id'));
    this.isEditMode = !!this.equipmentId;
    console.log(this.isEditMode);
    if (this.isEditMode) {
      this.loadEquipmentData(this.equipmentId!);
    }
  }
  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
  //simulamos el guardar
  onSubmit() {
    if (this.formData.economicNumber && this.formData.unitType) {
      if (this.isEditMode) {
        console.log('Equipo actualizado:', this.formData);
        alert('Equipo actualizado con éxito.');
      } else {
        console.log('Equipo creado:', this.formData);
        alert('Equipo guardado con éxito.');
      }
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
async loadEquipmentData(id: number) {
  try {
    const res: any = await this.equipmentService.getEquipmentById(id);
    const eq = res.Data ?? res;
    console.log('Equipo cargado:', eq);

    // Copia automática de propiedades directas
    Object.assign(this.formData, eq);

    // Mapeo de objetos anidados a campos del form
    this.formData.unitType = eq.equipmentType?.name ?? '';
    this.formData.unitTypeDescr = eq.equipmentType?.descr ?? '';
    this.formData.terminalName = eq.terminal?.nameTerminal ?? '';
    this.formData.tripTypeName = eq.tripType?.name ?? '';
    this.formData.habilitadoForaneo = eq.tripType?.id === 2;
    this.formData.estatusOperativo = eq.equipmentStatus?.name ?? '';
    this.formData.statusName = eq.equipmentStatus?.name ?? '';
  } catch (err) {
    console.error('Error al cargar equipo:', err);
  }
}
  
  // Cambiar título y botón según modo
  get pageTitle(): string {
    return this.isEditMode ? 'Editar Equipo' : 'Alta de Equipos';
  }

  get submitButtonText(): string {
    return this.isEditMode ? 'Actualizar Registro' : 'Guardar Registro';
  }
}
