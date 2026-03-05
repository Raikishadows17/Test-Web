import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientsDataView } from '../../views/clients-data-view/clients-data-view';
import { ContractRatesView } from '../../views/contract-rates-view/contract-rates-view';
import { AdressesContactsView } from '../../views/adresses-contacts-view/adresses-contacts-view';
import { CustomerService } from '../../catalogs/customer/customer.service';

@Component({
  selector: 'app-clients-contracts-form',
  imports: [CommonModule, FormsModule, ClientsDataView, ContractRatesView, AdressesContactsView],
  templateUrl: './clients-contracts-form.html',
  styleUrl: './clients-contracts-form.css',
})
export class ClientsContractsForm {
  isEditMode = false;
  customerId: number | null = null;
  activeTab = 1;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService
  ) {}

  formData: any = {
    // Campos del DTO
    nickname: '',
    names: '',
    middleName: '',
    lastName: '',
    fullName: '',
    companyName: '',
    rfcCompany: '',
    custPosition: '',
    urlWebPage: '',
    urlInvoicing: '',
    tripTypeId: null,
    paymentTermId: null,
    actualExecutiveId: null,
    contractActual: false,
    certificatedCustomer: false,
    baseContract: false,
    contractPersonalized: false,
    comments: '',
    contactos: [],

    // Campos UI extras (no van al DTO aún)
    industria: '',
    estatus: '',
    clienteFinal: false,
    freightForwarder: false,
    limiteCredito: 0,
    inicioContrato: '',
    finContrato: '',
    moneda: '',
    tipoContrato: '',
    fleteLocal: 0,
    estadiaDia: 0,
    pernocta: 0,
    movimientoFalso: 0,
    repartoAdicional: 0,
    diasLibresCarga: 0,
    diasLibresDescarga: 0,
    maniobraIMO: '',
    requierePortalesCita: false,

    rutas: [] as any[],

    docs: {
      constanciaFiscal: { custDocId: 1, file: null, urlDocumentPath: null },
      csr: { custDocId: 2, file: null, urlDocumentPath: null },
    },

    options: {
      industrias: ['Automotriz', 'Retail', 'Alimentos', 'Electrónica', 'Agro'],
      estatuses: ['Activo', 'Prospecto', 'Suspendido', 'Baja'],
      ejecutivos: ['Ana García', 'Carlos Ruiz', 'Ventas General'],
      terminosPago: ['Contado', 'Crédito 15 días', 'Crédito 30 días', 'Crédito 45 días'],
      monedas: ['MXN', 'USD'],
      tiposContrato: ['Indefinido', 'Por Proyecto', 'Temporada Alta'],
      tiposUnidad: ["Sencillo 40'", "Doble 40'", 'Refrigerado', 'Plana', 'Tolva'],
    },

    nuevaDireccion: {
      nombre: '', direccion: '', tipo: 'Fiscal',
      contacto: '', email: '', horario: '', mapaUrl: ''
    },
    direcciones: [],
  };

  async ngOnInit() {
    this.customerId = Number(this.route.snapshot.paramMap.get('id'));
    this.isEditMode = !!this.customerId;

    if (this.isEditMode) {
      await this.loadCustomerData(this.customerId!);
    }
  }

  setActiveTab(tab: number) {
    this.activeTab = tab;
  }

  async onSubmit() {
    if (!this.formData.nickname) {
      alert('Por favor, complete los campos obligatorios.');
      return;
    }

    const fd = new FormData();
    if (this.isEditMode) {
      fd.append('CustomerId', this.formData.customerId);
    }
    fd.append('Nickname', this.formData.nickname ?? '');
    fd.append('Names', this.formData.names ?? '');
    fd.append('MiddleName', this.formData.middleName ?? '');
    fd.append('LastName', this.formData.lastName ?? '');
    fd.append('FullName', this.formData.fullName ?? '');
    fd.append('CompanyName', this.formData.companyName ?? '');
    fd.append('RfcCompany', this.formData.rfcCompany ?? '');
    fd.append('CustPosition', this.formData.custPosition ?? '');
    fd.append('UrlWebPage', this.formData.urlWebPage ?? '');
    fd.append('UrlInvoicing', this.formData.urlInvoicing ?? '');
    fd.append('Comments', this.formData.comments ?? '');
    fd.append('ContractActual', this.formData.contractActual ?? false);
    fd.append('CertificatedCustomer', this.formData.certificatedCustomer ?? false);
    fd.append('BaseContract', this.formData.baseContract ?? false);
    fd.append('ContractPersonalized', this.formData.contractPersonalized ?? false);

    if (this.formData.tripTypeId) fd.append('TripTypeId', this.formData.tripTypeId);
    if (this.formData.paymentTermId) fd.append('PaymentTermId', this.formData.paymentTermId);
    if (this.formData.actualExecutiveId) fd.append('ActualExecutiveId', this.formData.actualExecutiveId);

    if (this.formData.docs.constanciaFiscal.file) {
      fd.append('ConstanciaSituacionFiscal', this.formData.docs.constanciaFiscal.file);
    }
    if (this.formData.docs.csr.file) {
      fd.append('CSR', this.formData.docs.csr.file);
    }

    // Direcciones
    if (this.formData.direcciones?.length) {
      this.formData.direcciones.forEach((dir: any, idx: number) => {
        if (dir.personalAddressesId) fd.append(`PersonalAddresses[${idx}].PersonalAddressesId`, dir.personalAddressesId);
        fd.append(`PersonalAddresses[${idx}].Category`, dir.tipo ?? '');
        fd.append(`PersonalAddresses[${idx}].FullAddress`, dir.direccion ?? '');
        fd.append(`PersonalAddresses[${idx}].City`, dir.ciudad ?? '');
        fd.append(`PersonalAddresses[${idx}].State`, dir.estado ?? '');
        fd.append(`PersonalAddresses[${idx}].ZipCode`, dir.cp ?? '');
        fd.append(`PersonalAddresses[${idx}].Country`, dir.pais ?? 'México');
        fd.append(`PersonalAddresses[${idx}].Comments`, dir.horario ?? '');
        fd.append(`PersonalAddresses[${idx}].MapsUrl`, dir.mapaUrl ?? '');
      });
    }

    // Contactos
    if (this.formData.contactos?.length) {
      this.formData.contactos.forEach((con: any, idx: number) => {
        if (con.personalContactId) fd.append(`PersonalContacts[${idx}].PersonalContactId`, con.personalContactId);
        fd.append(`PersonalContacts[${idx}].Name`, con.nombre ?? '');
        fd.append(`PersonalContacts[${idx}].Value`, con.valor ?? '');
        fd.append(`PersonalContacts[${idx}].Certificated`, con.certificated ?? false);
        fd.append(`PersonalContacts[${idx}].Comments`, con.comments ?? '');
      });
    }

    try {
      if (this.isEditMode) {
        await this.customerService.updateCustomer(fd);
        alert('Cliente actualizado con éxito.');
      } else {
        await this.customerService.createCustomer(fd);
        alert('Cliente creado con éxito.');
      }
      this.router.navigate(['/dashboard/customer']);
    } catch (err) {
      const error = err as any;
      console.error('Error:', error.error);
      alert('Error al guardar el cliente.');
    }
  }

  async loadCustomerData(id: number) {
    try {
      const res: any = await this.customerService.getCustomerById(id);
      const cust = res.Data ?? res;
      Object.assign(this.formData, cust);
      if (cust.customerFiles) {
          for (const file of cust.customerFiles) {
            if (file.custDocId === 1) {
              this.formData.docs.constanciaFiscal.urlDocumentPath = file.urlDocumentPath;
            }
            if (file.custDocId === 2) {
              this.formData.docs.csr.urlDocumentPath = file.urlDocumentPath;
            }
          }
        }

        // Cargar direcciones existentes
        if (cust.personalAddresses) {
          this.formData.direcciones = cust.personalAddresses.map((a: any) => ({
            personalAddressesId: a.personalAddressesId,
            nombre: a.reference1 ?? a.category ?? '',
            direccion: a.fullAddress ?? '',
            tipo: a.category ?? 'Fiscal',
            ciudad: a.city ?? '',
            estado: a.state ?? '',
            cp: a.zipCode ?? '',
            pais: a.country ?? 'México',
            contacto: '',
            email: '',
            horario: a.comments ?? '',
            mapaUrl: a.mapsUrl ?? ''
          }));
        }

        // Cargar contactos existentes
        if (cust.personalContacts) {
          this.formData.contactos = cust.personalContacts.map((c: any) => ({
            personalContactId: c.personalContactId,
            nombre: c.name ?? '',
            valor: c.value ?? '',
            certificated: c.certificated ?? false,
            comments: c.comments ?? ''
          }));
        }
    } catch (err) {
      console.error('Error al cargar cliente:', err);
    }
  }

  get pageTitle(): string {
    return this.isEditMode ? 'Editar Cliente' : 'Alta de Cliente';
  }

  get submitButtonText(): string {
    return this.isEditMode ? 'Actualizar Registro' : 'Guardar Registro';
  }
}