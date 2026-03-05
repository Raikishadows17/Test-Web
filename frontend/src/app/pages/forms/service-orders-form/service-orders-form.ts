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
  folio: string | null = null;
  isSubmitting = false;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private servicesOrdenServices: ServicesOrdenServices) { }



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
      tripTypes: [],
      statuses: ['Programado', 'En Tránsito', 'En Planta', 'Finalizado', 'Facturado'],
      operators: [],
      tractors: ['ECO-55 (Kenworth)', 'ECO-90 (Freightliner)'],
      trailers: ['Chasis 40ft - CH01', 'Plana - PL02'],
      containerTypes: [],
      loadStatuses: ['Lleno', 'Vacio'],
      expenseConcepts: ['Diesel', 'Casetas (Tag)', 'Maniobra', 'Talachas', 'Estadia', 'Comidas'],
      paymentMethods: ['Efectivo', 'Transferencia', 'Tag', 'Vale'],
      placesOrigin: ['Puerto Lázaro Cárdenas', 'Patio Regulador', 'Bodega Cliente'],
      placesDestination: ['CDMX Pantaco', 'Planta Querétaro', 'Guadalajara'],
      dollies: ['Dolly 01', 'Dolly 02', 'Dolly 03'],
      currencies: ['USD', 'MXN', 'EUR'],
      imoClasses: [],
      numberContainers: [],
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
    }

  };
  ngOnInit() {
    this.loadOptions();
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

    if (this.isSubmitting) return; // evita doble envío
    this.isSubmitting = true;

    const operacion = this.isEditMode ? 'actualizar' : 'crear';
    const mensajeExito = `Orden ${this.isEditMode ? 'actualizada' : 'creada'} con éxito`;

    const observable = this.isEditMode
      ? this.servicesOrdenServices.updateOrdenService(this.folio!, this.formData)
      : this.servicesOrdenServices.newOrdenService(this.formData);

    observable.subscribe({
      next: (response) => {
        alert(mensajeExito);
        this.router.navigate(['/dashboard/service-request']);
      },
      error: (error) => {
        console.error(`Error al ${operacion} orden:`, error);
        alert(`Error al ${operacion} orden. Por favor, intenta de nuevo.`);
      },
      complete: () => this.isSubmitting = false
    });
  }

  get pageTitle(): string {
    return this.isEditMode ? 'Editar Orden de Servicio' : 'Nueva Orden de Servicio';
  }
  get submitButtonText(): string {
    return this.isEditMode ? 'Actualizar Orden de Servicio' : 'Crear Orden de Servicio';
  }
  private loadOptions() {
    this.servicesOrdenServices.getServiceCreationOptions().subscribe({

      next: (data) => {
        const backendData = data.Data;

        // Mapear correctamente lo que viene del backend
        this.formData.options = {
          ...this.formData.options,
          operators: backendData.operator || [],
          tripTypes: backendData.tripType || [],
          imoClasses: backendData.imo || [],
          numberContainers: backendData.container || [],
          containerTypes: backendData.containerType || []

        };

        console.log('Operadores cargados:', this.formData.options.containerTypes);
      },
      error: (error) => {
        console.error('Error al cargar opciones:', error);
      }
    })
  }
}
