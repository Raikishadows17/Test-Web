import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servicerequest',
  imports: [CommonModule, FormsModule],
  templateUrl: './servicerequest.html',
  styleUrl: './servicerequest.css',
})
export class Servicerequest {
  constructor(private router: Router) { }
  // Filtros
  filters = {
    cliente: '',
    destino: '',
    operador: '',
    equipo: '',
    localForaneo: '',
    estatus: ''
  };

  // Lista completa de solicitudes (ejemplo, puedes traerlas de un servicio)
  solicitudes = [
    {
      folio: 'SERV-2026-001',
      cliente: 'Cliente Alpha',
      tripType: 'Foráneo',
      status: 'Programado',
      originPlace: 'Puerto Lázaro Cárdenas',
      destinationPlace: 'CDMX Pantaco',
      operator: 'Juan Pérez',
      tractor: 'ECO-55',
      containerNumber: 'TTRU1234567',
      solicitud: '2026-01-20T08:00',
      programada: '2026-01-21T06:00',
      citaCarga: '2026-01-21T09:00',
      citaDescarga: '2026-01-22T14:00'
    },
    {
      folio: 'SERV-2026-002',
      cliente: 'Samsung Lázaro Cárdenas',
      tripType: 'Local',
      status: 'En Tránsito',
      originPlace: 'Patio Regulador',
      destinationPlace: 'Planta Querétaro',
      operator: 'Luis Hernández',
      tractor: 'ECO-90',
      containerNumber: 'MEDU9876543',
      solicitud: '2026-01-19T14:30',
      programada: '2026-01-20T07:00',
      citaCarga: '2026-01-20T10:00',
      citaDescarga: '2026-01-20T16:00'
    },
    {
      folio: 'SERV-2026-003',
      cliente: 'Proveedor Automotriz',
      tripType: 'Local',
      status: 'Finalizado',
      originPlace: 'Patio Regulador',
      destinationPlace: 'Planta Querétaro',
      operator: 'Elias Gómez',
      tractor: 'ECO-101',
      containerNumber: 'MEDU9876543',
      solicitud: '2026-01-19T14:30',
      programada: '2026-01-20T07:00',
      citaCarga: '2026-01-20T10:00',
      citaDescarga: '2026-01-20T16:00'
    },
    // ... agrega más o trae de backend
  ];
  // Lista filtrada (se actualiza con filtros)
  filteredSolicitudes = [...this.solicitudes];

  // Opciones para selects (puedes traerlas de un servicio)
  estatuses = ['Programado', 'En Tránsito', 'En Planta', 'Finalizado', 'Facturado'];
  newService() {
    this.router.navigate(['/dashboard/service-request/new']);
  }
  applyFilters() {
    this.filteredSolicitudes = this.solicitudes.filter(s => {
      return (
        (!this.filters.cliente || s.cliente.toLowerCase().includes(this.filters.cliente.toLowerCase())) &&
        (!this.filters.destino || s.destinationPlace.toLowerCase().includes(this.filters.destino.toLowerCase())) &&
        (!this.filters.operador || s.operator.toLowerCase().includes(this.filters.operador.toLowerCase())) &&
        (!this.filters.equipo || s.tractor.toLowerCase().includes(this.filters.equipo.toLowerCase())) &&
        (!this.filters.localForaneo || s.tripType === this.filters.localForaneo) &&
        (!this.filters.estatus || s.status === this.filters.estatus)
      );
    });
  }

  clearFilters() {
    this.filters = {
      cliente: '',
      destino: '',
      operador: '',
      equipo: '',
      localForaneo: '',
      estatus: ''
    };
    this.filteredSolicitudes = [...this.solicitudes];
  }

  viewSolicitud(folio: string) {
    // Lógica para ver detalles (puedes abrir modal o navegar)
    console.log('Ver solicitud:', folio);
    alert('Ver detalles de: ' + folio);
  }

  editSolicitud(folio: string) {
    // Navegar al formulario en modo edición
    this.router.navigate(['/dashboard/service-request/update', folio]);
  }
}
