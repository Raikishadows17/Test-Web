import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ServicesOrdenGeneralRutaView } from "../../views/services-orden-general-ruta-view/services-orden-general-ruta-view";
import { ServicesOrdenAssignmentLoadView } from "../../views/services-orden-assignment-load-view/services-orden-assignment-load-view";
import { ServicesOrdenEvidenceView } from "../../views/services-orden-evidence-view/services-orden-evidence-view";
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesOrdenOperationalMonitoringView } from "../../views/services-orden-operational-monitoring-view/services-orden-operational-monitoring-view";
import { ServicesOrdenIncidentsDiscountsView } from "../../views/services-orden-incidents-discounts-view/services-orden-incidents-discounts-view";
import { ServicesOrdenServices } from '../../services/servicesorden.service';

@Component({
  selector: 'app-service-orders-form',
  imports: [CommonModule, FormsModule, ServicesOrdenGeneralRutaView, ServicesOrdenAssignmentLoadView, ServicesOrdenEvidenceView, ServicesOrdenOperationalMonitoringView, ServicesOrdenIncidentsDiscountsView],
  templateUrl: './service-orders-form.html',
  styleUrl: './service-orders-form.css',
})
export class ServiceOrdersForm {
  activeTab = 1;
  isEditMode = false;
  serviceId: number | null = null;
  isSubmitting = false;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private servicesOrdenServices: ServicesOrdenServices) { }



  // Datos del formulario (puedes separarlos por tab si quieres)
  formData: any = {
    //tab 1 - Datos generales
    folio: '',
    client: '',
    tripType: '',
    status: '',
    daterequest: '',
    datescheduled: '',
    datecarry: '',
    datedownload: '',
    dateclosing: '',
    provisionalLocalTeam: false,
    originPlace: '',
    originUrlMap: '',
    destinationPlace: '',
    destinationAddress: '',
    estimatedKm: '',
    estimatedTime: '',
    requiresOvernight: false,
    destinations: [{ place: '', address: '', mapUrl: '' }],
    statuProgram: '',


    //Tab 2 - Carga y asignación
    operator: '',
    loadStatus1: '',
    loadStatus1b: '',
    loadStatus2: '',
    loadStatus2b: '',
    outdoorPatioReason: '',
    seal1: '',
    seal2: '',
    pedimentoClient: '',
    isFull: false,
    isSocio: false,
    noSolicitarEquipo: false,

    tractor: '',
    chasisMain: '',
    containerNumber1: '',
    dolly: '',
    containerNumber2: '',
    tractoColor: '#ffffff',
    colorContainer1: '#ffffff',
    colorContainer1b: '#ffffff',
    colorContainer2: '#ffffff',
    colorContainer2b: '#ffffff',
    chasisSecundario: '',


    shippingline1: '',
    shippingline2: '',
    size1: '',
    size2: '',
    weight1: '',
    weight2: '',
    containerType1: '',
    containerType2: '',
    packaging1: '',
    packaging2: '',
    pedimentoCliente1: '',
    pedimentoCliente2: '',
    pedimentoNumber1: '',
    pedimentoNumber2: '',
    tariffClassification1: '',
    tariffClassification2: '',
    imo1: '',
    imo2: '',

    containerType1b: '',
    containerType2b: '',
    containerNumber1b: '',
    containerNumber2b: '',
    shippingline1b: '',
    shippingline2b: '',
    size1b: '',
    size2b: '',
    weight1b: '',
    weight2b: '',
    packaging1b: '',
    packaging2b: '',
    pedimentoCliente1b: '',
    pedimentoCliente2b: '',
    pedimentoNumber1b: '',
    pedimentoNumber2b: '',
    tariffClassification1b: '',
    tariffClassification2b: '',
    imo1b: '',
    imo2b: '',

    placa: '',
    noEconomico: '',

    //tab 3 - Evidencias y gastos
    newExpense: {
      date: new Date().toLocaleDateString('es-MX'),
      concept: '',
      amount: 0,
      paymentMethod: '',
      evidence: ''
    },
    expenses: [] as { date: string, concept: string, amount: number, paymentMethod: string, evidence: string }[],

    //tab 4 - Segimiento operativo
    terminal: '',
    terminalDestination: '',
    partners: '',
    authorizationDate: '',
    approvalDate: '', // (Vo.Bo.)
    serviceStartDate: '',

    // Terminal Withdrawal Movements
    withdrawalTicketTerminal: '',
    withdrawalBlock: '',
    estimatedArrivalDate: '',
    aslaRegistrationDate: '',
    terminalCallDate: '',
    facilityEntryDate: '',
    terminalArrivalDate: '',
    yardLoadingDate: '',
    yardWithdrawalDate: '',
    terminalDepartureDate: '',
    facilityDepartureDate: '',

    // Terminal Return Movements
    returnTerminal: '',
    depositBlock: '',
    returnTicketTerminal: '',
    returnTerminalArrivalDate: '',
    returnAslaRegistrationDate: '',
    returnFacilityEntryDate: '',
    returnTerminalDepartureDate: '',
    returnFacilityDepartureDate: '',
    yardDepositDate: '',
    returnEstimatedArrivalDate: '',

    // Documentation Dates
    waybillDate: '', // (Carta Porte)
    documentationDeliveryDate: '',

    // Closing and Delivery Dates
    arrivalDate: '',
    handlingDate: '',
    emptyDate: '',
    fullEmptyDate: '',
    preRegistration: '',
    dischargeCompletionDate: '',

    //tab 5 - Incidencias y descuentos
    //Taller Mecánico
    maintenancePartner: '',
    maintenanceAmount: null,
    maintenanceCurrency: '',
    maintenanceTax: null,
    maintenanceAmountDue: null,
    maintenancePaymentMethod: '',
    maintenanceReason: '',
    maintenanceDays: null,
    maintenanceReference: '', // (Adjudicación)
    selectedMaintenanceReceipt: null, // (Comprobante)

    //Incidencias
    redLightDate: '', // (Fecha Rojo - Aduana)
    redLightReleaseDate: '',
    overnightStayDate: '', // (Pernocta)
    overnightStayReleaseDate: '',
    deliveryDelayHours: null,
    dryRunMovement: null, // (Movimiento en falso / Deadhead)
    cancelledManeuver: '',
    customerDeliveryHours: null,
    restArea: '',
    restAreaStartTime: '',
    restAreaEndTime: '',

    //Descuentos
    discountAmount: null,
    discountPercentage: null,
    discountKms: null,
    discountReason: '',
    discountAdjudication: '',

    //Incidencia Carga Contenedor
    containerLoadingIncident: '',
    loadingReason: '',
    loadingTime: '',

    options: {
      clients: ['Walmart', 'Samsung Lázaro Cárdenas', 'Proveedor Automotriz'],
      tripTypes: [],
      statuses: ['Programado', 'En Tránsito', 'En Planta', 'Finalizado', 'Facturado'],
      operators: [],
      tractors: ['ECO-55 (Kenworth)', 'ECO-90 (Freightliner)'],
      trailers: ['Chasis 40ft - CH01', 'Plana - PL02'],
      loadStatuses: ['Lleno', 'Vacio'],
      expenseConcepts: ['Diesel', 'Casetas (Tag)', 'Maniobra', 'Talachas', 'Estadia', 'Comidas'],
      paymentMethods: ['Efectivo', 'Transferencia', 'Tag', 'Vale'],
      placesOrigin: ['Puerto Lázaro Cárdenas', 'Patio Regulador', 'Bodega Cliente'],
      placesDestination: ['CDMX Pantaco', 'Planta Querétaro', 'Guadalajara'],
      dollies: ['Dolly 01', 'Dolly 02', 'Dolly 03'],
      currencies: ['USD', 'MXN', 'EUR'],
      imoClasses: [],
      containers: [],
      equipments: [],
      statusesProgram: ['Default', 'Informativo'],
      routes: [
        { origen: 'CDMX Pantaco', destino: 'Planta Querétaro', urlMapa: 'https://maps.app.goo.gl/ejemplo1' },
        { origen: 'Lázaro Cárdenas', destino: 'CDMX Pantaco', urlMapa: 'https://maps.app.goo.gl/ejemplo2' },
        { origen: 'Guadalajara', destino: 'Monterrey', urlMapa: 'https://maps.app.goo.gl/ejemplo3' },
        { origen: 'Puerto Lázaro Cárdenas', destino: 'Tijuana', urlMapa: 'https://maps.app.goo.gl/ejemplo4' },
        { origen: 'Manzanillo', destino: 'León Guanajuato', urlMapa: 'https://maps.app.goo.gl/ejemplo5' },
        { origen: 'Veracruz', destino: 'Puebla', urlMapa: 'https://maps.app.goo.gl/ejemplo6' }
      ]
    },
    route: {
      selectedRoute: null as { origen: string; destino: string; urlMapa: string } | null
    },
    docs: {
      pedimento: { docId: 1, file: null, urlDocumentPath: null },
      cartaPorte: { docId: 2, file: null, urlDocumentPath: null },
      boletaTerminal: { docId: 3, file: null, urlDocumentPath: null },
      doda: { docId: 4, file: null, urlDocumentPath: null },
    }

  };
  async ngOnInit() {
    // Detectar si viene folio en la URL (modo edición)
    this.serviceId = Number(this.route.snapshot.paramMap.get('id'));
    this.isEditMode = !!this.serviceId;

    const res: any = await this.servicesOrdenServices.getServiceOptions();
    /*
       imo[9] tripType[2] equipment[102] terminal[16] container[10]
       containerType[6] roadRoutes[] customer[] operator[21]
       */
    this.formData.options.operators = res.Data.operator;
    this.formData.options.tripTypes = res.Data.tripType;
    this.formData.options.containers = res.Data.container;
    this.formData.options.equipments = res.Data.equipment;
    this.formData.options.imoClasses = res.Data.imo;

    if (this.isEditMode) {
      this.loadServiceData(this.serviceId!);
    } else {
      this.formData.folio = `SERV-${new Date().getFullYear()}-${Math.floor(1000 + Math.random() * 9000)}`;
    }

  }

  // Cambiar tab
  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
  async onSubmit() {
    if (!this.formData.folio) {
      alert('Po favor, complete los campos obligatorios!');
      return;
    }
    const fd = new FormData();

    // Datos generales
    fd.append('Folio', this.formData.folio ?? '');
    fd.append('Client', this.formData.client ?? '');
    fd.append('TripType', this.formData.tripType ?? '');
    fd.append('Status', this.formData.status ?? '');
    fd.append('DateRequest', this.formData.daterequest ?? '');
    fd.append('DateScheduled', this.formData.datescheduled ?? '');
    fd.append('DateCarry', this.formData.datecarry ?? '');
    fd.append('DateDownload', this.formData.datedownload ?? '');
    fd.append('DateClosing', this.formData.dateclosing ?? '');
    fd.append('RequiresOvernight', this.formData.requiresOvernight ?? false);
    fd.append('EstimatedKm', this.formData.estimatedKm ?? '');
    fd.append('EstimatedTime', this.formData.estimatedTime ?? '');
    fd.append('Instrucciones', this.formData.instrucciones ?? '');

    // Ruta
    fd.append('RouteOrigen', this.formData.route?.selectedRoute?.origen ?? '');
    fd.append('RouteDestino', this.formData.route?.selectedRoute?.destino ?? '');
    fd.append('RouteMapUrl', this.formData.route?.selectedRoute?.urlMapa ?? '');

    // Asignación
    fd.append('Operator', this.formData.operator ?? '');
    fd.append('Tractor', this.formData.tractor ?? '');
    fd.append('IsFull', this.formData.isFull ?? false);
    fd.append('IsSocio', this.formData.isSocio ?? false);
    fd.append('NoSolicitarEquipo', this.formData.noSolicitarEquipo ?? false);

    // Contenedor 1
    fd.append('ContainerType1', this.formData.containerType1 ?? '');
    fd.append('ContainerNumber1', this.formData.containerNumber1 ?? '');
    fd.append('ShippingLine1', this.formData.shippingline1 ?? '');
    fd.append('Size1', this.formData.size1 ?? '');
    fd.append('Weight1', this.formData.weight1 ?? '');
    fd.append('LoadStatus1', this.formData.loadStatus1 ?? '');
    fd.append('Seal1', this.formData.seal1 ?? '');
    fd.append('Seal2', this.formData.seal2 ?? '');
    fd.append('PedimentoCliente1', this.formData.pedimentoCliente1 ?? '');
    fd.append('PedimentoNumber1', this.formData.pedimentoNumber1 ?? '');
    fd.append('TariffClassification1', this.formData.tariffClassification1 ?? '');
    fd.append('Imo1', this.formData.imo1 ?? '');

    // Contenedor 1B
    fd.append('ContainerType1b', this.formData.containerType1b ?? '');
    fd.append('ContainerNumber1b', this.formData.containerNumber1b ?? '');
    fd.append('ShippingLine1b', this.formData.shippingline1b ?? '');
    fd.append('Size1b', this.formData.size1b ?? '');
    fd.append('Weight1b', this.formData.weight1b ?? '');
    fd.append('LoadStatus1b', this.formData.loadStatus1b ?? '');

    // Contenedor 2
    fd.append('ContainerType2', this.formData.containerType2 ?? '');
    fd.append('ContainerNumber2', this.formData.containerNumber2 ?? '');
    fd.append('ShippingLine2', this.formData.shippingline2 ?? '');
    fd.append('Size2', this.formData.size2 ?? '');
    fd.append('Weight2', this.formData.weight2 ?? '');
    fd.append('LoadStatus2', this.formData.loadStatus2 ?? '');

    // Contenedor 2B
    fd.append('ContainerType2b', this.formData.containerType2b ?? '');
    fd.append('ContainerNumber2b', this.formData.containerNumber2b ?? '');
    fd.append('ShippingLine2b', this.formData.shippingline2b ?? '');
    fd.append('Size2b', this.formData.size2b ?? '');
    fd.append('Weight2b', this.formData.weight2b ?? '');
    fd.append('LoadStatus2b', this.formData.loadStatus2b ?? '');

    //docs
    const docs = this.formData.docs as any;
    let idx = 0;
    for (const key of Object.keys(docs)) {
      const doc = docs[key];
      if (doc.file || doc.urlDocumentPath) {
        fd.append(`ServiceFiles[${idx}].DocId`, doc.docId);
        fd.append(`ServiceFiles[${idx}].Name`, key);
        if (doc.urlDocumentPath) fd.append(`ServiceFiles[${idx}].UrlDocumentPath`, doc.urlDocumentPath);
        if (doc.file) fd.append(`ServiceFiles[${idx}].File`, doc.file);
        idx++;
      }
    }

    try {
      if (this.isEditMode) {
        fd.append('ServiceId', this.formData.serviceId);
        await this.servicesOrdenServices.updateService(fd);
        alert('Servicio actualizado con éxito!');
      } else {
        await this.servicesOrdenServices.createService(fd);
        alert('Servicio creado con éxito');
      }
      this.router.navigate(['dashboard/service-request']);
    } catch (err) {
      const error = err as any;
      console.error('Error al guardar:', error);
      console.error('Detalle:', error.error);
      alert('Error al guardar el equipo.');
    }
  }
  private async loadServiceData(id: number) {
    try {
      const res: any = await this.servicesOrdenServices.getServiceById(id);
      const service = res.Data ?? res;

      // Mezclar datos del backend con el formData
      Object.assign(this.formData, service);

      // Mapear ruta si viene del backend
      if (service.routeOrigen && service.routeDestino) {
        this.formData.route.selectedRoute = {
          origen: service.routeOrigen,
          destino: service.routeDestino,
          urlMapa: service.routeMapUrl ?? ''
        };
      }

      // Mapear docs si vienen del backend
      if (service.serviceFiles) {

        const docMap: any = {
          1: 'pedimento',
          2: 'cartaPorte',
          3: 'boletaTerminal',
          4: 'doda'
        };
        const docs = this.formData.docs as any;
        for (const file of service.serviceFiles) {
          const key = docMap[file.docId];
          if (key && docs[key]) {
            docs[key].urlDocumentPath = file.urlDocumentPath;
          }
        }
      }

    } catch (err) {
      console.error('Error al cargar servicio:', err);
      alert('No se pudo cargar la orden de servicio.');
    }
  }

  get pageTitle(): string {
    return this.isEditMode ? 'Editar Orden de Servicio' : 'Nueva Orden de Servicio';
  }
  get submitButtonText(): string {
    return this.isEditMode ? 'Actualizar Orden de Servicio' : 'Crear Orden de Servicio';
  }
}
