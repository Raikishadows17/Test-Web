import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ServicesOrdenGeneralRutaView } from "../../views/services-orden-general-ruta-view/services-orden-general-ruta-view";
import { ServicesOrdenAssignmentLoadView } from "../../views/services-orden-assignment-load-view/services-orden-assignment-load-view";
import { ServicesOrdenEvidenceView } from "../../views/services-orden-evidence-view/services-orden-evidence-view";
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesOrdenOperationalMonitoringView } from "../../views/services-orden-operational-monitoring-view/services-orden-operational-monitoring-view";
import { ServicesOrdenIncidentsDiscountsView } from "../../views/services-orden-incidents-discounts-view/services-orden-incidents-discounts-view";

@Component({
  selector: 'app-service-orders-form',
  imports: [CommonModule, FormsModule, ServicesOrdenGeneralRutaView, ServicesOrdenAssignmentLoadView, ServicesOrdenEvidenceView, ServicesOrdenOperationalMonitoringView, ServicesOrdenIncidentsDiscountsView],
  templateUrl: './service-orders-form.html',
  styleUrl: './service-orders-form.css',
})
export class ServiceOrdersForm {
  activeTab = 1;
  isEditMode = false;
  folio: string | null = null;

  constructor(private route: ActivatedRoute, private router: Router) { }

  // Datos del formulario (puedes separarlos por tab si quieres)
  formData = {
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

    //Tab 2 - Carga y asignación
    operator: '',
    loadStatus: '',
    outdoorPatioReason: '',
    seal1: '',
    seal2: '',
    pedimentoClient: '',
    isFull: false,
    isSocio: false,
    noSolicitarEquipo: false,

    tractor: '',
    tractoColor: '#ffffff',
    chasisMain: '',
    containerNumber1: '',
    dolly: '',
    containerNumber2: '',
    chasisPrincipalColor: '#ffffff',
    dollyColor: '#ffffff',
    chasisSecundarioColor: '#ffffff',
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

    placa: '',
    noEconomico: '',

    selectedPedimento: '',
    selectedCartaPorte: '',
    selectedBoletaTerminal: '',
    selectedDoda: '',

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
      tripTypes: ['Local', 'Foráneo'],
      statuses: ['Programado', 'En Tránsito', 'En Planta', 'Finalizado', 'Facturado'],
      operators: ['Juan Pérez (Disponible)', 'Luis López (Disponible)', 'Ana Gómez'],
      tractors: ['ECO-55 (Kenworth)', 'ECO-90 (Freightliner)'],
      trailers: ['Chasis 40ft - CH01', 'Plana - PL02'],
      containerTypes: ['20 DC', '40 DC', '40 HC', 'Refrigerado'],
      loadStatuses: ['Lleno', 'Vacío'],
      expenseConcepts: ['Diesel', 'Casetas (Tag)', 'Maniobra', 'Talachas', 'Estadia', 'Comidas'],
      paymentMethods: ['Efectivo', 'Transferencia', 'Tag', 'Vale'],
      placesOrigin: ['Puerto Lázaro Cárdenas', 'Patio Regulador', 'Bodega Cliente'],
      placesDestination: ['CDMX Pantaco', 'Planta Querétaro', 'Guadalajara'],
      dollies: ['Dolly 01', 'Dolly 02', 'Dolly 03'],
      currencies: ['USD', 'MXN', 'EUR'],
      imoClasses: [
        { value: '1', label: 'Clase 1 - Explosivos' },
        { value: '2.1', label: 'Clase 2.1 - Gases inflamables' },
        { value: '2.2', label: 'Clase 2.2 - Gases no inflamables, no tóxicos' },
        { value: '2.3', label: 'Clase 2.3 - Gases tóxicos' },
        { value: '3', label: 'Clase 3 - Líquidos inflamables' },
        { value: '4.1', label: 'Clase 4.1 - Sólidos inflamables' },
        { value: '4.2', label: 'Clase 4.2 - Sustancias que pueden inflamarse espontáneamente' },
        { value: '4.3', label: 'Clase 4.3 - Sustancias que al contacto con agua emiten gases inflamables' },
        { value: '5.1', label: 'Clase 5.1 - Sustancias oxidantes' },
        { value: '5.2', label: 'Clase 5.2 - Peróxidos orgánicos' },
        { value: '6.1', label: 'Clase 6.1 - Sustancias tóxicas' },
        { value: '6.2', label: 'Clase 6.2 - Material infeccioso' },
        { value: '7', label: 'Clase 7 - Material radiactivo' },
        { value: '8', label: 'Clase 8 - Sustancias corrosivas' },
        { value: '9', label: 'Clase 9 - Sustancias peligrosas varias' },
        { value: 'NA', label: 'No aplica / Mercancía general' }
      ]
    },


  };
  ngOnInit() {
    // Detectar si viene folio en la URL (modo edición)
    this.folio = this.route.snapshot.paramMap.get('folio');
    this.isEditMode = !!this.folio;

    if (this.isEditMode) {
      const selectedService = history.state?.selectedService;
      if (selectedService) {
        this.formData = { ...this.formData, ...selectedService };
      } else {
        alert('No se encontró la orden con folio: ' + this.folio);
      }
    } else {
      this.formData.folio = `SERV-${new Date().getFullYear()}-${Math.floor(1000 + Math.random() * 9000)}`;
    }

  }

  // Cambiar tab
  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
  onSubmit() {
    console.log('Orden de servicio enviada:', this.formData);
    alert('Orden guardada con éxito');
  }

  get pageTitle(): string {
    return this.isEditMode ? 'Editar Orden de Servicio' : 'Nueva Orden de Servicio';
  }
  get submitButtonText(): string {
    return this.isEditMode ? 'Actualizar Orden de Servicio' : 'Crear Orden de Servicio';
  }
}
