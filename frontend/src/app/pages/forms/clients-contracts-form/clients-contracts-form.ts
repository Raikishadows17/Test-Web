import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ClientsDataView } from "../../views/clients-data-view/clients-data-view";
import { ContractRatesView } from "../../views/contract-rates-view/contract-rates-view";
import { AdressesContactsView } from "../../views/adresses-contacts-view/adresses-contacts-view";

@Component({
  selector: 'app-clients-contracts-form',
  imports: [CommonModule, FormsModule, ClientsDataView, ContractRatesView, AdressesContactsView],
  templateUrl: './clients-contracts-form.html',
  styleUrl: './clients-contracts-form.css',
})
export class ClientsContractsForm {
  activeTab = 1;


  formData = {
    rfc: '',
    razonSocial: '',
    nombreComercial: '',
    industria: '',
    estatus: '',
    clienteFinal: false,
    freightForwarder: false,
    ejecutivoCuenta: '',
    terminosPago: '',
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
    rutas: [
      {
        origen: 'Lázaro Cárdenas, MICH',
        destino: 'Cuautitlán, MEX',
        tipoUnidad: "Sencillo 40'",
        tarifa: 28500.00
      }
    ] as { origen: string; destino: string; tipoUnidad: string; tarifa: number }[],
    options: {
      industrias: ['Automotriz', 'Retail', 'Alimentos', 'Electrónica', 'Agro'],
      estatuses: ['Activo', 'Prospecto', 'Suspendido', 'Baja'],
      ejecutivos: ['Ana García', 'Carlos Ruiz', 'Ventas General'],
      terminosPago: ['Contado (Anticipado)', 'Crédito 15 días', 'Crédito 30 días', 'Crédito 45 días'],
      monedas: ['MXN - Pesos Mexicanos', 'USD - Dólares Americanos'],
      tiposContrato: ['Indefinido', 'Por Proyecto', 'Temporada Alta'],
      tiposUnidad: ['Sencillo 40\'', 'Doble 40\'', 'Refrigerado', 'Plana', 'Tolva', 'Otro'],
    },
    nuevaDireccion: {
      nombre: '',
      direccion: '',
      tipo: 'Fiscal',
      contacto: '',
      email: '',
      horario: '',
      mapaUrl: ''
    },
    direcciones: [
      {
        nombre: 'Oficinas Centrales',
        direccion: 'Av. Reforma 222, Col. Juárez, CP 06600, CDMX',
        tipo: 'Fiscal',
        contacto: 'Lic. Finanzas',
        email: 'facturacion@cliente.com',
        horario: 'L-V 8:00 - 18:00',
        mapaUrl: ''
      }
    ],
  };


  //Opciones


  setActiveTab(tab: number) {
    this.activeTab = tab;
  }

  onSubmit() {
    console.log('Cliente/Contrato guardado:', this.formData);
    alert('Registro guardado');
  }



}
