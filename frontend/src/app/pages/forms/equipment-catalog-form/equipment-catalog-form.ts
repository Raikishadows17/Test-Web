import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EquipmentGeneralView } from '../../views/equipment-general-view/equipment-general-view';
import { EquipmentVisualPhotoView } from "../../views/equipment-visual-photo-view/equipment-visual-photo-view";
import { EquipmentService } from '../../catalogs/equipment/equipment.service';
import { environment } from '../../../../environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-equipment-catalog-form',
  imports: [CommonModule, FormsModule, EquipmentGeneralView, EquipmentVisualPhotoView],
  templateUrl: './equipment-catalog-form.html',
  styleUrl: './equipment-catalog-form.css',
  
})
export class EquipmentCatalogForm {
  isEditMode = false;
  equipmentId: number | null = null;
  constructor(private route: ActivatedRoute,private equipmentService: EquipmentService,private router: Router) {  }

  equipmentTypes: any[] = [];

  apiURL = environment.apiURL;

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
    imageURLFront: null,
    imageURLSide: null,
    imageURLBack: null,
    imageURLUp: null,    
    unitType: '',
    unitTypeDescr: '',
    terminalName: '',
    tripTypeName: '',
    statusName: '',
    habilitadoForaneo: false,

    fuelType: '',
    ejes: '',
    description: '',
    modelYear: null,    
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

    docs: {
      facturaCompra:    { eqpmDocId: 1, file: null, urlDocumentPath: null },
      tituloCompra:     { eqpmDocId: 2, file: null, urlDocumentPath: null },
      estudioMecanico:  { eqpmDocId: 3, file: null, urlDocumentPath: null, dateApply: null, dateExp: null, state: null },
      hologramas:       { eqpmDocId: 4, file: null, urlDocumentPath: null, dateApply: null, dateExp: null, state: null },
      verificacion:     { eqpmDocId: 5, file: null, urlDocumentPath: null, dateExp: null },
      polizaSeguro:     { eqpmDocId: 6, file: null, urlDocumentPath: null, dateExp: null, comments: null },
      documentoSeguro:  { eqpmDocId: 7, file: null, urlDocumentPath: null, dateApply: null, dateExp: null },
    },

    options: {
      unitType: [],
      years: Array.from({ length: 30 }, (_, i) => 2025 - i),
      fuelTypes: ['Diésel', 'Gasolina', 'Gas Natural'], // No se necesita
      axles: ['2', '3', '4', '5', '6'],//No se necesita
      positions: ['Patio A', 'Patio B', 'Patio C', 'En ruta'],//No se necesita
      currentStatus: ['Disponible', 'En servicio', 'En mantenimiento', 'Fuera de servicio'], //NO SE NECESITA, SE CREA COMO DISPONIBLE POR DEFAULT
      typemaintenance: ['Preventivo', 'Correctivo', 'Mayor'] //NO SE NECESITA
    },
  };
  

  async ngOnInit() {
    this.equipmentId = Number(this.route.snapshot.paramMap.get('id'));
    this.isEditMode = !!this.equipmentId;    

    const res: any = await this.equipmentService.getEquipmentType();    
    this.formData.options.unitType = res.Data ?? res ?? [];
    
    if (this.isEditMode) {
      this.loadEquipmentData(this.equipmentId!);
    }
  }
  setActiveTab(tab: number) {
    this.activeTab = tab;
  }

  async onSubmit() {
  if (!this.formData.economicNumber) {
    alert('Por favor, complete los campos obligatorios.');
    return;
  }

  const fd = new FormData();
  //fd.append('EquipmentId', this.formData.equipmentId ?? '');
  fd.append('EquipTypeId', this.formData.equipTypeId ?? '');
  //fd.append('TerminalId', this.formData.terminalId ?? '');
  fd.append('TripTypeId', this.formData.tripTypeId === 2 ? '2' : '1');
  fd.append('EconomicNumber', this.formData.economicNumber ?? '');
  fd.append('Plates', this.formData.plates ?? '');
  fd.append('Description', this.formData.description ?? '');
  fd.append('ModelYear', this.formData.modelYear ?? '');
  fd.append('PlatesEstate', this.formData.platesEstate ?? '');
  fd.append('DieselCapacity', this.formData.dieselCapacity ?? '');
  fd.append('TowingCapacity', this.formData.towingCapacity ?? '');
  fd.append('AvailablePartners', this.formData.availablePartners ?? false);
  fd.append('LabeledUnit', this.formData.labeledUnit ?? false);
  fd.append('SerialNumber', this.formData.serialNumber ?? '');
  fd.append('BrandName', this.formData.brandName ?? '');
  fd.append('Color', this.formData.color ?? '');
  fd.append('ImageURLFront', this.formData.imageURLFront ?? '');
  fd.append('ImageURLSide', this.formData.imageURLSide ?? '');
  fd.append('ImageURLBack', this.formData.imageURLBack ?? '');
  fd.append('ImageURLUp', this.formData.imageURLUp ?? '');

  // Adjuntar archivos si el usuario seleccionó nuevos
  const imageFiles = this.formData.imageFiles ?? {};
  if (imageFiles.front) fd.append('ImageFront', imageFiles.front);
  if (imageFiles.side) fd.append('ImageSide', imageFiles.side);
  if (imageFiles.back) fd.append('ImageBack', imageFiles.back);
  if (imageFiles.up) fd.append('ImageUp', imageFiles.up);

  const docs = this.formData.docs;
  let idx = 0;
  for (const key of Object.keys(docs)) {
    const doc = docs[key];
    // Solo enviar si tiene archivo o datos de fechas
    if (doc.file || doc.dateApply || doc.dateExp || doc.state || doc.comments || doc.urlDocumentPath) {
      fd.append(`EquipmentFiles[${idx}].EqpmDocId`, doc.eqpmDocId);
      fd.append(`EquipmentFiles[${idx}].Name`, key);
      if (doc.state) fd.append(`EquipmentFiles[${idx}].State`, doc.state);
      if (doc.dateApply) fd.append(`EquipmentFiles[${idx}].DateApply`, doc.dateApply);
      if (doc.dateExp) fd.append(`EquipmentFiles[${idx}].DateExp`, doc.dateExp);
      if (doc.comments) fd.append(`EquipmentFiles[${idx}].Comments`, doc.comments);
      if (doc.urlDocumentPath) fd.append(`EquipmentFiles[${idx}].UrlDocumentPath`, doc.urlDocumentPath);
      if (doc.file) fd.append(`EquipmentFiles[${idx}].File`, doc.file);
      idx++;
    }
  }

  try {
    if (this.isEditMode) {
      fd.append('EquipmentId', this.formData.equipmentId);
      await this.equipmentService.updateEquipment(fd);
      alert('Equipo actualizado con éxito.');
    } else {
      await this.equipmentService.createEquipment(fd);
      alert('Equipo creado con éxito.');
    }
    this.router.navigate(['/dashboard/equipment']);
  } catch (err) {
    const error = err as any;
    console.error('Error al guardar:', error);
    console.error('Detalle:', error.error);
    alert('Error al guardar el equipo.');
  }
  
}
  
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

      Object.assign(this.formData, eq);

      this.formData.unitType = eq.equipmentType?.name ?? '';
      this.formData.unitTypeDescr = eq.equipmentType?.descr ?? '';
      this.formData.terminalName = eq.terminal?.nameTerminal ?? '';
      this.formData.tripTypeName = eq.tripType?.name ?? '';
      this.formData.habilitadoForaneo = eq.tripType?.id === 2;
      this.formData.estatusOperativo = eq.equipmentStatus?.name ?? '';
      this.formData.statusName = eq.equipmentStatus?.name ?? '';

      // Cargar documentos existentes en la estructura docs
      if (eq.equipmentFiles) {
        for (const file of eq.equipmentFiles) {
          const docMap: any = {
            1: 'facturaCompra',
            2: 'tituloCompra',
            3: 'estudioMecanico',
            4: 'hologramas',
            5: 'verificacion',
            6: 'polizaSeguro',
            7: 'documentoSeguro'
          };
          const key = docMap[file.eqpmDocId];
          if (key && this.formData.docs[key]) {
            this.formData.docs[key].urlDocumentPath = file.urlDocumentPath;
            this.formData.docs[key].dateApply = file.dateApply?.split('T')[0] ?? null;
            this.formData.docs[key].dateExp = file.dateExp?.split('T')[0] ?? null;
            this.formData.docs[key].state = file.state;
            this.formData.docs[key].comments = file.comments;
          }
        }
      }
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
